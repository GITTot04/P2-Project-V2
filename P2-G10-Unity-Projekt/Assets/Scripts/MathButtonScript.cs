using UnityEngine;
using UnityEngine.UI;

public class MathButtonScript : MonoBehaviour
{
    public int buttonID;
    Color32 selectedColor = new Color32(150, 150, 150, 255);
    Color32 defaultColor = new Color32(255, 255, 255, 255);
    void Start()
    {
        
    }

    public void SelectAnswer()
    {
        foreach (GameObject answerButton in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            answerButton.GetComponent<Image>().color = defaultColor;
        }
        GetComponent<Image>().color = selectedColor;
    }



}
