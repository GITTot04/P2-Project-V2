using UnityEngine;
using UnityEngine.UI;

public class MathResults : MonoBehaviour
{
    [SerializeField] GameObject correctAnswerButton1;
    [SerializeField] GameObject correctAnswerButton2;
    [SerializeField] GameObject correctAnswerButton3;
    Color32 incorrectColor = new Color32(255, 0, 0, 255);
    Color32 correctColor = new Color32(0, 255, 0, 255);

    void Start()
    {
        if (!GameControllerScript.gameController.answer1Result)
        {
            foreach (GameObject answerButton in GameObject.FindGameObjectsWithTag("Question1Button"))
            {
                if (answerButton.GetComponent<MathButtonScript>().buttonID == GameControllerScript.gameController.chosenAnswer1)
                {
                    answerButton.GetComponent<Image>().color = incorrectColor;
                }
            }
        }
        else
        {
            correctAnswerButton1.GetComponent<Image>().color = correctColor; ;
        }
        if (!GameControllerScript.gameController.answer2Result)
        {
            foreach (GameObject answerButton in GameObject.FindGameObjectsWithTag("Question2Button"))
            {
                if (answerButton.GetComponent<MathButtonScript>().buttonID == GameControllerScript.gameController.chosenAnswer2)
                {
                    answerButton.GetComponent<Image>().color = incorrectColor;
                }
            }
        }
        else
        {
            correctAnswerButton2.GetComponent<Image>().color = correctColor; ;
        }
        if (!GameControllerScript.gameController.answer3Result)
        {
            foreach (GameObject answerButton in GameObject.FindGameObjectsWithTag("Question3Button"))
            {
                if (answerButton.GetComponent<MathButtonScript>().buttonID == GameControllerScript.gameController.chosenAnswer3)
                {
                    answerButton.GetComponent<Image>().color = incorrectColor;
                }
            }
        }
        else
        {
            correctAnswerButton3.GetComponent<Image>().color = correctColor; ;
        }
    }
}
