using UnityEngine;
using UnityEngine.UI;

public class EmojiSpawner : MonoBehaviour
{
    public GameObject[] emojiPlacement;
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
        messagingScript.emojiSpot1 = false;
        messagingScript.emojiSpot2 = false;
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
        if(messagingScript.emojiSpot1 == false)
        {
          a = Instantiate(spriteRend, emojiPlacement[0].transform.position, emojiPlacement[0].transform.rotation);
        
        messagingScript.emojiButton.SetActive(true);
            messagingScript.emojiSpot1 = true;
        }
        else if(messagingScript.emojiSpot2 == false)
        {
            b = Instantiate(spriteRend, emojiPlacement[1].transform.position, emojiPlacement[1].transform.rotation);

            messagingScript.emojiButton.SetActive(true);
            messagingScript.emojiSpot2 = true;
        }
        if(messagingScript.emojiSpot1 == true && messagingScript.emojiSpot2 == true)
        {
            a = b;
            b = Instantiate(spriteRend, emojiPlacement[1].transform.position, emojiPlacement[1].transform.rotation);

        }
        
    }
}
