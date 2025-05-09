using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour
{
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite clickedSprite;
    public void ChangeSprite() 
    {
        if (GetComponent<Image>().sprite != clickedSprite)
        {
            GetComponent<Image>().sprite = clickedSprite;
        }
        else
        {
            GetComponent<Image>().sprite = defaultSprite;
        }
    }
}
