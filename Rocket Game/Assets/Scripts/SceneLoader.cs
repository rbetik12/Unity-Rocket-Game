using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader: MonoBehaviour {

    public void LoadGameScene() {
        SceneManager.LoadScene("Game Scene 2.0");
    }

    IEnumerator LoadAsync() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game Scene 2.0");

        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}