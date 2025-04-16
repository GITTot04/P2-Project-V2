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
    public GameObject/*[]*/ messageBoble;
    public GameObject TextHolder;
    public TextMeshPro messageText;
    private string textString;
    //public GameObject boble;
    public string[] messages = { "I am loving Lego", "We are NOT gamers in distress, we are GAMERS IN POWER!!!!!", "Send Nudes", "I believe that we should legalize something, not sure what tho", "Play games, Gain Bitches", "Who is my best friend from somewhere far below this line of balls" };
    public int randomNumber;
    public int characterLengthLimit = 20;
    public GameObject emojiButton;
    public GameObject emojiPanel;
    public GameObject emoji1;
    public GameObject emojiPlacement;
    private SpriteRenderer spriteHolder;
    // The offset of the sprite to hide it.
    private Vector2 startPosition = new Vector2(0f,0f);
    private Vector2 endPosition = Vector2.zero;
    // How long it takes to show a mole.
    private float showDuration = 0.5f;
    private float duration = 1f;

    public int characterAdder = 0;

    private SpriteRenderer spriteRendererMessageBoble;
    [SerializeField] private Vector2 messageBobleSize;// = new Vector2(0f, 0.8f);
    [SerializeField] private Vector3 messageBoblePos;// = new Vector3(0f, -1f, 0f);
    [SerializeField] private Vector3 textPos;//= new Vector3(0.3f, -0.5f, 0f);
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;
    public Vector3 scaleChanger;
    //public EmojiSpawner emojiSpawnerScript;
    //public GameObject[] emoMe;
    public void Awake()
    {
        spriteRendererMessageBoble = messageBoble.GetComponent<SpriteRenderer>();
        spriteRendererMessageBoble.drawMode = SpriteDrawMode.Sliced;
        rb = messageBoble.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        
    }
    public void Start()
    {
        
        //messageBoble.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Dancing knuckle gif funny deez nuts");
        messageBoble.gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        randomNumber = Random.Range(0, messages.Length);
        //messages = new string[randomNumber];
        messageText.text = messages[randomNumber];
        textString = messageText.text;
        //boble = messageBoble[randomNumber];
        /*
        //ShowHide(scaleChanger, endPosition);
        boxCollider2D = messageBoble.GetComponent<BoxCollider2D>();
            // Work out collider values.
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
        */
        
        int charLenHolder = characterLengthLimit;
         while(textString.Length >= characterLengthLimit + characterAdder)
        {
            spriteRendererMessageBoble.size += messageBobleSize;
            messageBoble.transform.position += messageBoblePos;
            messageText.transform.position += textPos;
            Debug.Log("Sprite size: " + spriteRendererMessageBoble.size.ToString("F2"));
            characterAdder += charLenHolder; 

        }
        emojiButton.SetActive(true);
        emojiPanel.SetActive(false);
        emoji1.SetActive(false);
        emojiButton.transform.position += messageBoblePos - new Vector3(0.0f, 0.03f, 0f);
        emojiPlacement.transform.position += messageBoblePos - new Vector3(0, 0.04f, 0);
    }
    public void Update()
    {
        TextHolder.transform.position = textPos; //messageBoble.transform.TransformVector(textPos); 
        
    }
    /*private IEnumerator ShowHide(Vector2 start, Vector2 end)
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
    }*/
        public void EmojiButton()
    {
        
        emojiButton.SetActive(false);
        emojiPanel.SetActive(true);
        emojiPanel.transform.position += messageBoblePos - new Vector3(0, 0.02f, 0);
    }

    /*public void EmojiPanel()
    {  emojiPanel.SetActive(false);
        spriteHolder = GetComponent<SpriteRenderer>();
        //spriteHolder = transform.position += new Vector3(0, 0, -5), transform.rotation;
        //emojiPlacement = spriteHolder.transform.position += new Vector3(0,0,-5), transform.rotation);
       emojiPlacement.SetActive(true);
        
    }*/
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == true)
        {
            new Vector3(0.01f, 0.01f, 0f);
        }
    }
}
