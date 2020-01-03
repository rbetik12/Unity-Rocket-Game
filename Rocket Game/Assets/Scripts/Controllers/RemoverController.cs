using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverController : MonoBehaviour {

    private GameController gameController;

    private void Start() {
        gameController = GameObject.Find("Game Loop").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Spikes")) {
            Destroy(other.gameObject);
            gameController.ReduceSpikesAmount();
        }
    }
}
