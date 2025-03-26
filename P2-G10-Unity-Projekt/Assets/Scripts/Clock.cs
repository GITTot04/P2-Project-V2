using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    void LateUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = GameControllerScript.gameController.time;
    }
}
