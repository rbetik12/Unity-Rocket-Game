using UnityEngine.EventSystems;
using UnityEngine;


public class ClickDetector : MonoBehaviour, IPointerClickHandler {

    [SerializeField] SceneLoader sceneLoader;

    public void OnPointerClick(PointerEventData eventData) {
        sceneLoader.LoadGameScene();
    }

}