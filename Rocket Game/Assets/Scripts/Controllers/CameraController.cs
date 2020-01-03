using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject rocket;

    void Update() {
        float x = rocket.transform.position.x;
        float y = Mathf.Clamp(rocket.transform.position.y, -11f, 11f);
        transform.position = new Vector3(x, y, -10);

    }
}
