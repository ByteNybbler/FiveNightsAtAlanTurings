using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    // How many seconds the spikes wait to thrust after spawning.
    float thrustTimer = 2f;
    // How many seconds it takes for the spikes to disappear after thrusting.
    float spikesExistTime = 15f;
    // The speed at which the spikes move when they thrust.
    float moveSpeed = 50f;

    AudioSource aud;
    AudioClip spikeThrust;
    bool thrusted = false;

    Vector3 moveVector = Vector3.zero;

	private void Start ()
    {
        aud = GameObject.Find("AudioController").GetComponent<AudioSource>();
        spikeThrust = (AudioClip)Resources.Load("Sound Effects/StrangeMechanicalSound");
    }

    private void Update()
    {
        thrustTimer -= Time.deltaTime;
        // After waiting for a bit...
        if (!thrusted && thrustTimer < 0)
        {
            thrusted = true;
            // Play spike thrusting sound.
            aud.PlayOneShot(spikeThrust);
            // Set the move vector's y component.
            moveVector.y = moveSpeed;
        }
        // Once the spikes exist for long enough...
        if (thrustTimer < -spikesExistTime)
        {
            Destroy(gameObject);
        }
        transform.position += moveVector * Time.deltaTime;
    }

    public void BackOff()
    {
        moveVector.y = -moveSpeed;
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, transform.localScale.z);
    }
}
