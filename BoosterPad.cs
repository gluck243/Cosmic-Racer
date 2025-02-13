using UnityEngine;

public class BoosterPad : MonoBehaviour {
    public GameObject player;
    [SerializeField]
    private float turboAmount;
    [SerializeField]
    private float turboDuration;
    private float lastTurboAt;

    // private bool isBoosting;

    void Start() {
        lastTurboAt = -turboDuration; // So that the player can boost immediately
    }

    void FixedUpdate() {
        if (Time.time - lastTurboAt < turboDuration) { // If the player is boosting
            player.GetComponent<Rigidbody>().AddForce(transform.forward * turboAmount); // Add force to the player
        }

        /*if (Time.time - lastTurboAt >= turboDuration) { // If the player is not boosting
            isBoosting = false;
        }*/

        /*if (isBoosting) { // If the player is boosting
            player.GetComponent<Rigidbody>().AddForce(transform.forward * turboAmount); // Add force to the player
        }*/
    }

    private void OnTriggerEnter(Collider other) { // When the player enters the booster pad
        if (Time.time - lastTurboAt >= turboDuration) { // If the player is not boosting
            if (other.tag == "Player") { 
                Debug.Log("Player entered the booster pad");
                // isBoosting = true; 
                lastTurboAt = Time.time; 
            }
        }
    }
}