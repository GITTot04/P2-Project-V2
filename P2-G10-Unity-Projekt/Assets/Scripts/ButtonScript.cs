using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    string leaderboardText;
    public void GetPoint()
    {
        if (GameControllerScript.gameController.buttonGameCooldown <= 0)
        {
            GameControllerScript.gameController.buttonGamePoints++;
            GameControllerScript.gameController.buttonGameCooldown = 30;
            GameObject.Find("ButtonPointText").GetComponent<TextMeshProUGUI>().text = "Point: " + GameControllerScript.gameController.buttonGamePoints;
            switch (GameControllerScript.gameController.buttonGamePoints)
            {
                case 7:
                    leaderboardText = "Leaderboard:" + "\n" + "\n";
                    leaderboardText += "1. TheLegend27: 9" + "\n";
                    leaderboardText += "2. User01032: 8" + "\n";
                    leaderboardText += "3. Dig!: 7";
                    GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                    break;
                case 8:
                    leaderboardText = "Leaderboard:" + "\n" + "\n";
                    leaderboardText += "1. TheLegend27: 9" + "\n";
                    leaderboardText += "2. Dig!: 8" + "\n";
                    leaderboardText += "3. User01032: 8";
                    GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                    break;
                case 9:
                    leaderboardText = "Leaderboard:" + "\n" + "\n";
                    leaderboardText += "1. Dig!: 9" + "\n";
                    leaderboardText += "2. TheLegend27: 9" + "\n";
                    leaderboardText += "3. User01032: 8";
                    GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                    break;
                default:
                    break;
            }
        }
    }
}
