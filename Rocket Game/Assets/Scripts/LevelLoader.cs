using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
    public Animator transition;
    public float transitionTime = 1f;
    public void LoadGameScene() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int sceneIndex) {
        Debug.Log("Started animation");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        switch (sceneIndex) {
            case 0:
                SceneLoader.LoadStartScene();
                break;
            case 1:
                SceneLoader.LoadGameScene();
                break;
        }

    }
}