using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StartButtonEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] TextMeshProUGUI startLabel;

    public void OnPointerClick(PointerEventData eventData) {
        SceneLoader.LoadGameScene();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        startLabel.color = new Color(70 / 256f, 79 / 256f, 214 / 256f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        startLabel.color = Color.white;
    }
}