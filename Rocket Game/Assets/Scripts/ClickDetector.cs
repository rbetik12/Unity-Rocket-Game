using UnityEngine.EventSystems;
using UnityEngine;


public class ClickDetector : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData) {
        SceneLoader.LoadGameScene();
    }

}