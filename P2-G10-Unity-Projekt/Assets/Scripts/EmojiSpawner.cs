using UnityEngine;
using UnityEngine.UI;

public class EmojiSpawner : MonoBehaviour
{
    
    public GameObject emojiPanel;
    public GameObject spriteRend;
    public Messaging messagingScript;
    public Transform emojiPanelT;
    public Vector3 originalScaling;
    public Vector3 scaling;
    GameObject a;
    GameObject b;

    public void Awake()
    {
        originalScaling = spriteRend.transform.localScale;
        //messagingScript.emojiSpot1 = false;
        //messagingScript.emojiSpot2 = false;
        //spriteRend.transform.localScale = originalScaling;
    }
    public void OrignalScale()
    {
        spriteRend.transform.localScale = originalScaling;
        spriteRend.GetComponent<Button>().enabled = true;
    }
    public void EmojiSpawning(/*Transform emojiPlacement*/)
    {
        
        //scaling = new Vector3(0.5f, 0.5f, 0.5f);
        emojiPanel.SetActive(false);
        spriteRend.GetComponent<Button>().enabled = false;
        /*spriteRend.transform.SetParent(emojiPlacement);
        spriteRend.transform.SetParent(emojiPlacement.transform, false);
        spriteRend.transform.SetParent(null);*/
        spriteRend.transform.localScale = scaling;
        if(messagingScript.emojiSpot1 == false && messagingScript.spawnedMessage1 == true)
        {
          a = Instantiate(spriteRend, messagingScript.emojiPlacement[0].transform.position, messagingScript.emojiPlacement[0].transform.rotation);
            messagingScript.emoji1 = a;
            messagingScript.emoji1.transform.position = messagingScript.emojiPlacement[0].transform.position;

            //messagingScript.emojiButton.SetActive(true);
            messagingScript.emojiSpot1 = true;
        }
        else if(messagingScript.emojiSpot2 == false && messagingScript.spawnedMessage2 == true)
        {
            b = Instantiate(spriteRend, messagingScript.emojiPlacement[1].transform.position, messagingScript.emojiPlacement[1].transform.rotation);
            messagingScript.emoji2 = b;
            messagingScript.emoji2.transform.position = messagingScript.emojiPlacement[1].transform.position;

            //messagingScript.emojiButton.SetActive(true);
            messagingScript.emojiSpot2 = true;
        }
        if (messagingScript.emojiSpot2 == true && messagingScript.spawnedMessage2 == true)
        {
            messagingScript.emoji1 = messagingScript.emoji2;
            messagingScript.emoji2 = null;
            //b = Instantiate(spriteRend, emojiPlacement[1].transform.position, emojiPlacement[1].transform.rotation);
            b = Instantiate(spriteRend, messagingScript.emojiPlacement[1].transform.position, messagingScript.emojiPlacement[1].transform.rotation);
            messagingScript.emoji2 = b;
            messagingScript.emoji2.transform.position = messagingScript.emojiPlacement[1].transform.position;
            //b.transform.position = messagingScript.emojiPlacement[1].transform.position;

        }
        
    }
}
