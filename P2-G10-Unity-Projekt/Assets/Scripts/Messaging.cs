using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using JetBrains.Annotations;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Collections;

public class Messaging : MonoBehaviour
{
    public Sprite profilePic;
    public GameObject messageBoble;
    public TextMeshPro messageText;
    public string[] messages = { "I am loving Lego", "We are NOT gamers in distress, we are GAMERS IN POWER!!!!!", "Send Nudes", "I believe that we should legalize something, not sure what tho", "Play games, Gain Bitches", "Who is my best friend from somewhere far below this line of balls" };
    public int randomNumber;
    public GameObject emojiButton;
    public GameObject emojiPanel;
    public GameObject emoji1;
    public GameObject emojiPlacement;
    // The offset of the sprite to hide it.
    private Vector2 startPosition = new Vector2(0f,0f);
    private Vector2 endPosition = Vector2.zero;
    // How long it takes to show a mole.
    private float showDuration = 0.5f;
    private float duration = 1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;
    public Vector3 scaleChanger;
    public void Start()
    {
        randomNumber = Random.Range(0, messages.Length);
        //messages = new string[randomNumber];
        messageText.text = messages[randomNumber];
        
        
            spriteRenderer = messageBoble.GetComponent<SpriteRenderer>();
            ShowHide(scaleChanger, endPosition);
            boxCollider2D = messageBoble.GetComponent<BoxCollider2D>();
            // Work out collider values.
            boxOffset = boxCollider2D.offset;
            boxSize = boxCollider2D.size;
            boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
            boxSizeHidden = new Vector2(boxSize.x, 0f);

        
        emojiButton.SetActive(true);
        emojiPanel.SetActive(false);
        emoji1.SetActive(false);
    }
    public void Update()
    {
        
    }
    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Make sure we start at the start.
        transform.localPosition = start;

        // Show the mole.
        float elapsed = 0f;
        //while (elapsed < showDuration)
        //{
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            scaleChanger = transform.localScale = new Vector3(0f, 3f, 0f);
            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            messageBoble.transform.localScale += scaleChanger;
            // Update at max framerate.
            elapsed += Time.deltaTime;
            yield return null;
       // }

        // Make sure we're exactly at the end.
        transform.localPosition = end;
        boxCollider2D.offset = boxOffset;
        boxCollider2D.size = boxSize;

        // Wait for duration to pass.
        yield return new WaitForSeconds(duration);
    }
        public void EmojiButton()
    {
        emojiButton.SetActive(false);
        emojiPanel.SetActive(true);
    }
    public void EmojiPanel()
    {  emojiPanel.SetActive(false);
       emojiPlacement = Instantiate(emoji1, transform.position += new Vector3(0,0,-5), transform.rotation);
        emojiPlacement.SetActive(true);
        
    }
}
