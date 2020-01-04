using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public static void LoadGameScene() {
        SceneManager.LoadScene("Game Scene 2.0");
    }

    IEnumerator LoadAsync() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game Scene 2.0");

        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    public static void LoadStartScene() {
        SceneManager.LoadScene("Start Screen");
    }
}