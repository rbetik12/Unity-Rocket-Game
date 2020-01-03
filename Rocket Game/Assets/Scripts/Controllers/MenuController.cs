using UnityEngine;
using TMPro;
public class MenuController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI highscoreLabel;

    void Start() {
        PlayerData data = SaveSystem.LoadData();
        if (data == null)
            highscoreLabel.text += " 0";
        else
            highscoreLabel.text += " " + data.highscore.ToString();
    }
}
