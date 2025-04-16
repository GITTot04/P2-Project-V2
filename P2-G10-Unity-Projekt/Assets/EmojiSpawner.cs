using UnityEngine;
using UnityEngine.UI;

public class EmojiSpawner : MonoBehaviour
{
    public GameObject emojiPlacement;
    public GameObject emojiPanel;
    public GameObject spriteRend;
    public Messaging messagingScript;
    public Transform emojiPanelT;
    public Vector3 originalScaling;
    public Vector3 scaling;

    public void Awake()
    {
        originalScaling = spriteRend.transform.localScale;
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
        Instantiate(spriteRend,emojiPlacement.transform.position, emojiPlacement.transform.rotation);
        
        messagingScript.emojiButton.SetActive(true);
    }
}
