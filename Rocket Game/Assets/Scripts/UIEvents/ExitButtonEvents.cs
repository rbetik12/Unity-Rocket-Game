using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ExitButtonEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TextMeshProUGUI exitLabel;

    public void OnPointerClick(PointerEventData eventData) {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        exitLabel.color = new Color(70 / 256f, 79 / 256f, 214 / 256f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        exitLabel.color = Color.white;
    }
}
