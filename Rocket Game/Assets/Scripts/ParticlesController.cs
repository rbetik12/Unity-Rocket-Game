using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {
    private GameObject fireParticles;
    [SerializeField] private GameObject rocket;

    private ParticleSystem fireParticlesSystem;

    void Start() {
        // fireParticlesSystem = fireParticlesSystem.GetComponent<ParticleSystem>();
    }

    void Update() {
    }
}
