using TMPro;
using UnityEngine;
public class MenuController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI highscoreLabel;
    [SerializeField] private LevelLoader levelLoader;
    public void Start() {
        PlayerData data = SaveSystem.LoadData();
        if (data == null)
            highscoreLabel.text += " 0";
        else
            highscoreLabel.text += " " + data.highscore.ToString();
    }

    public void OnStartClick() {
        Debug.Log("Clicked start");
        levelLoader.LoadGameScene();
    }

    public void OnStartRelease() {
    }

    public void OnExitClick() {
        Application.Quit();
    }
}