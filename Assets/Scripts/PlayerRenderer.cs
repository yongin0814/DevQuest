using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour {
    [Header("Preset Fields")]
    public PlayerControl pcon;
    public ParticleSystem walkParticle;

    [Header("Settings")]
    public float turnSpeed = 3f;

    private bool isWalking;

    private void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, pcon.rotation, Time.deltaTime * turnSpeed);

        if(pcon.landed && pcon.moving) {
            if (!isWalking) {
                isWalking = true;
                walkParticle.time = 0f;
                walkParticle.Play();
            }
        }
        else {
            if (isWalking) {
                isWalking = false;
                walkParticle.Stop();
            }
        }
    }
}
