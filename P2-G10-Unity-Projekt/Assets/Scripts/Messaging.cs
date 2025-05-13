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
    public GameObject TextHolder;
    public GameObject[] sender;
    public GameObject[] user;
    public GameObject[] elementHolderSender;
    public GameObject[] elementHolderUser;
    public TextMeshPro messageText;
    private string textString;
    //public GameObject boble;
    public string[] messages = { "I am loving Lego", "We are NOT gamers in distress, we are GAMERS IN POWER!!!!!", "Send Nudes", "I believe that we should legalize something, not sure what tho", "Play games, Gain Bitches", "Who is my best friend from somewhere far below this line of balls" };
    public int randomNumber;
    public int characterLengthLimit = 20;
    public GameObject emojiButton;
    public GameObject emojiPanel;
    public GameObject emoji1;
    //public GameObject[] emojiPlacement;
    private SpriteRenderer spriteHolder;
    GameObject a;
    GameObject b;
    public int moreThanTwo = 0;
    public bool emojiSpot1 = false;
    public bool emojiSpot2 = false;

    public int characterAdder = 0;
    public float timerForSpawning;

    private SpriteRenderer spriteRendererMessageBoble;
    [SerializeField] private Vector2 messageBobleSize;// = new Vector2(0f, 0.8f);
    [SerializeField] private Vector3 messageBoblePos;// = new Vector3(0f, -1f, 0f);
    [SerializeField] private Vector3 textPos;//= new Vector3(0.3f, -0.5f, 0f);
    private Rigidbody2D rb;
    private Animator animator;
    //public EmojiSpawner emojiSpawnerScript;
    //public GameObject[] emoMe;
    public void Awake()
    {
        StartCoroutine(SpawningTimer());
        
    }
    public void Start()
    {
        
       

    }
    public void Update()
    {
         //StartCoroutine(SpawningTimer());
        
    }
   
        public void EmojiButton()
    {
        
        b.SetActive(false);
        /*
        emojiPanel.SetActive(true);
        emojiPanel.transform.position -= messageBoblePos - new Vector3(0, 0.05f, 0);*/
        Instantiate(emojiPanel).transform.position = b.transform.position+new Vector3(-1.5f,0.8f,0f);
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
            new Vector3(0f, 0.01f, 0f);
        }
    }
    public void MessageFrom()
    {
        //Instantiate(emojiButton);
        //emojiButton.transform.position = emojiPlacement[0].transform.position;
       
        
        
        /*spriteRendererMessageBoble = messageBoble.GetComponent<SpriteRenderer>();
        spriteRendererMessageBoble.drawMode = SpriteDrawMode.Sliced;
        rb = messageBoble.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;


        messageBoble.gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        randomNumber = Random.Range(0, messages.Length);
        //messages = new string[randomNumber];
        messageText.text = messages[randomNumber];
        textString = messageText.text;

        int charLenHolder = characterLengthLimit;
        while (textString.Length >= characterLengthLimit + characterAdder)
        {
            spriteRendererMessageBoble.size += messageBobleSize;
            messageBoble.transform.position += messageBoblePos;
            messageText.transform.position += textPos;
            Debug.Log("Sprite size: " + spriteRendererMessageBoble.size.ToString("F2"));
            characterAdder += charLenHolder;
            TextHolder.transform.position = textPos;
        }
        charLenHolder = 0;
        */
        /* Instantiate(emojiButton).SetActive(true);
         Instantiate(emojiPanel).SetActive(false);
         Instantiate(emoji1).SetActive(false);
         emojiButton.transform.position = emojiPlacement.transform.position;
         emojiButton.transform.position += messageBoblePos - new Vector3(0.0f, 0.05f, 0f);
         emojiPlacement.transform.position += messageBoblePos - new Vector3(0, 0.05f, 0);*/
        int moreThanTwo = 0;
        if (moreThanTwo > 2)
        { 
            elementHolderSender[0].transform.position = a.transform.position;
            elementHolderUser[0].transform.position = b.transform.position;
            a = Instantiate(sender[Random.Range(0, sender.Length)]);
            b = Instantiate(user[0]);
           
            //a = Instantiate(sender[0]);
            a.transform.position = elementHolderSender[1].transform.position;
            b.transform.position = elementHolderUser[1].transform.position;
            moreThanTwo++;
            StartCoroutine(SpawningTimer());

        }
        if(moreThanTwo > 1)
        {
            a = Instantiate(sender[Random.Range(0, sender.Length)]);
            b = Instantiate(user[0]);

            //a = Instantiate(sender[0]);
            a.transform.position = elementHolderSender[1].transform.position;
            b.transform.position = elementHolderUser[1].transform.position;
            moreThanTwo++;
            StartCoroutine(SpawningTimer());
        }
        a = Instantiate(sender[Random.Range(0, sender.Length)]);
        b = Instantiate(user[0]);
        a.transform.position = elementHolderSender[0].transform.position;
        b.transform.position = elementHolderUser[0].transform.position;


        moreThanTwo += 1;
        StartCoroutine(SpawningTimer());
    }
    public IEnumerator SpawningTimer()
    {
        float timer = timerForSpawning;
        while (timerForSpawning > 0)
        {
            timerForSpawning -= Time.unscaledDeltaTime;
            
            yield return null;
        }
        timerForSpawning = timer;
        MessageFrom();
        
    }
}
