using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsIniitializer : MonoBehaviour
{
    GameObject statsTextObject;
    string statsText;

    private void Awake()
    {
        statsTextObject = GameObject.Find("Stats Text");
        statsText += "Tid brugt på matematik: " + "\n" + (int)GameControllerScript.gameController.timeSpentOnMath + " sekunder" + "\n" + "\n";
        statsText += "Tid brugt på video: " + "\n" + (int)GameControllerScript.gameController.timeSpentOnVideo + " sekunder" + "\n" + "\n";
        statsText += "Tid brugt på beskeder: " + "\n" + (int)GameControllerScript.gameController.timeSpentOnMessages + " sekunder" + "\n" + "\n";
        statsText += "Tid brugt på knap spil: " + "\n" + (int)GameControllerScript.gameController.timeSpentOnButtonGame + " sekunder" + "\n" + "\n";
        statsText += "Point i knap spil: " + "\n" + GameControllerScript.gameController.buttonGamePoints;
        statsTextObject.GetComponent<TextMeshProUGUI>().text = statsText;
    }
}
