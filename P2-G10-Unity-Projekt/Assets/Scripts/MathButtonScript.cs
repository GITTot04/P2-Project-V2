using UnityEngine;
using UnityEngine.UI;

public class MathButtonScript : MonoBehaviour
{
    public int buttonID;
    Color32 selectedColor = new Color32(150, 150, 150, 255);
    Color32 defaultColor = new Color32(255, 255, 255, 255);

    void Awake()
    {
        switch (tag)
        {
            case "Question1Button":
                if (GameControllerScript.gameController.chosenAnswer1 == buttonID)
                {
                    GetComponent<Image>().color = selectedColor;
                }
                break;
            case "Question2Button":
                if (GameControllerScript.gameController.chosenAnswer2 == buttonID)
                {
                    GetComponent<Image>().color = selectedColor;
                }
                break;
            case "Question3Button":
                if (GameControllerScript.gameController.chosenAnswer3 == buttonID)
                {
                    GetComponent<Image>().color = selectedColor;
                }
                break;
            default:
                break;
        }
    }

    public void SelectAnswer()
    {
        foreach (GameObject answerButton in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            answerButton.GetComponent<Image>().color = defaultColor;
        }
        GetComponent<Image>().color = selectedColor;
        switch (tag)
        {
            case "Question1Button":
                GameControllerScript.gameController.chosenAnswer1 = buttonID;
                if (buttonID == GameControllerScript.gameController.correctAnswerOption1)
                {
                    GameControllerScript.gameController.answer1Result = true;
                }
                else
                {
                    GameControllerScript.gameController.answer1Result = false;
                }
                break;
            case "Question2Button":
                GameControllerScript.gameController.chosenAnswer2 = buttonID;
                if (buttonID == GameControllerScript.gameController.correctAnswerOption2)
                {
                    GameControllerScript.gameController.answer2Result = true;
                }
                else
                {
                    GameControllerScript.gameController.answer2Result = false;
                }
                break;
            case "Question3Button":
                GameControllerScript.gameController.chosenAnswer3 = buttonID;
                if (buttonID == GameControllerScript.gameController.correctAnswerOption3)
                {
                    GameControllerScript.gameController.answer3Result = true;
                }
                else
                {
                    GameControllerScript.gameController.answer3Result = false;
                }
                break;
            default:
                break;
        }
    }
}
