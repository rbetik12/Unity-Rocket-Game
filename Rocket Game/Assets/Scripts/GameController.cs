using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour {

    [SerializeField] private GameObject spikes;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI restartLabel;
    [SerializeField] private TextMeshProUGUI pressToStartLabel;

    private RocketController rocketController;
    private GameObject rocket;
    private Rigidbody2D rocketRb;
    private int spikesAmount = 0;
    private int score = 0;
    private int spikesX = 10;
    private int distance_between_spikes = 17;
    private bool gameStarted = false;

    private const int MAX_SPIKES = 4;
    private const float SPIKES_SPEED = 7f;

    void Start() {
        rocket = GameObject.Find("Rocket");
        rocketController = rocket.GetComponent<RocketController>();
        rocketController.StartFire();
        rocketRb = rocket.GetComponent<Rigidbody2D>();
        rocketRb.bodyType = RigidbodyType2D.Static;
        restartLabel.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(false);
    }

    void Update() {
        if (gameStarted) {
            SpawnSpikes();
            if (!rocketController.IsAlive()) {
                StopSpikes();
                ActivateRestart();
            }
            UpdateScore();
        }
        else {
            CheckForStart();
        }
        CheckForExit();
    }

    public void ReduceSpikesAmount() {
        spikesAmount -= 1;
    }

    public void IncScore() {
        score += 1;
    }

    private void CheckForExit() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void CheckForStart() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gameStarted = true;
            rocketRb.bodyType = RigidbodyType2D.Dynamic;
            rocketController.StopFire();
            scoreLabel.gameObject.SetActive(true);
            pressToStartLabel.gameObject.SetActive(false);
        }
    }

    private void SpawnSpikes() {
        if (spikesAmount < MAX_SPIKES) {
            GameObject spikesObj = Instantiate(spikes);
            spikesObj.transform.position = new Vector3(spikesX, Random.Range(-6, 6), 0);
            spikesObj.GetComponent<Rigidbody2D>().velocity = Vector3.left * SPIKES_SPEED;
            spikesAmount += 1;
            spikesX += distance_between_spikes;
        } else {
            spikesX = 25;
            distance_between_spikes = 20;
        }
    }

    private void StopSpikes() {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spikes");
        foreach (GameObject spike in spikes) {
            spike.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void UpdateScore() {
        scoreLabel.SetText(score.ToString());
    }

    private void ActivateRestart() {
        restartLabel.gameObject.SetActive(true);
    }

}
