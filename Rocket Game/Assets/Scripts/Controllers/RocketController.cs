﻿using System.Collections;
using UnityEngine;

public class RocketController : MonoBehaviour {

    [SerializeField] private GameObject rocket;
    [SerializeField] private AudioClip[] sounds;

    private Rigidbody2D rb;
    private float gravity;
    private bool alive = true;
    private bool spacePressed = false;
    private bool fireStarted = false;
    private bool restartClicked = false;
    private GameController gameController;
    private ParticleSystem fireParticleSys;
    private AudioSource audioSource;

    void Start() {
        gameController = GameObject.Find("Game Loop").GetComponent<GameController>();
        fireParticleSys = GameObject.Find("Fire").GetComponent<ParticleSystem>();

        rb = rocket.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        gravity = rb.gravityScale;
        alive = true;
        Debug.Log("Spawned rocket");
    }

    void Update() {
        if (!alive) {
            HandleRestartInput();
            if (restartClicked)
                return;
        }
        HandleInput();
        RotateRocket();
        SpawnParticles();
    }

    private void HandleRestartInput() {
        if ((Input.GetKeyDown(KeyCode.Space))) {
            restartClicked = true;
        } else if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) {
                restartClicked = true;
            }
        }
    }

    public bool IsRestartClicked() {
        return restartClicked;
    }

    private void FixedUpdate() {
        if (spacePressed) {
            rb.AddForce(Vector2.up * Time.deltaTime * gravity * 2f);
            Debug.Log("Force applied");
            spacePressed = false;
            audioSource.PlayOneShot(sounds[0]);
        }
    }

    private void HandleInput() {
        if (alive && (Input.GetKeyDown(KeyCode.Space))) {
            Debug.Log("Space pressed");
            spacePressed = true;
        } else if (alive && Input.touchCount > 0) {
            Debug.Log("Touch count: " + Input.touchCount);
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) {
                spacePressed = true;
            }
        }
    }

    private void RotateRocket() {
        Quaternion towardsVelocityRotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg - 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, towardsVelocityRotation, Time.deltaTime * 10f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Spikes") || other.gameObject.tag.Equals("Wall")) {
            spacePressed = false;
            rb.velocity = new Vector3(0, 0, 0);
            if (alive) {
                audioSource.PlayOneShot(sounds[1]);
            }
            alive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("ScoreHitbox")) {
            gameController.IncScore();
        }
    }

    public bool IsAlive() {
        return alive;
    }

    private void SpawnParticles() {
        if (!fireStarted && Input.GetKey(KeyCode.Space)) {
            StartCoroutine(CreateFireParticles());
        }
    }

    IEnumerator CreateFireParticles() {
        fireStarted = true;
        fireParticleSys.Play();
        yield return new WaitForSeconds(0.5f);
        fireParticleSys.Stop();
        fireStarted = false;
    }

    public void StartFire() {
        if (fireParticleSys == null)
            return;
        fireParticleSys.Play();
    }

    public void StopFire() {
        if (fireParticleSys == null)
            return;
        fireParticleSys.Stop();
    }
}