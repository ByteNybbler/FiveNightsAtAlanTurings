// Paul Calande

using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
    const float TIMERMAX = 0.4f;
    float timer = TIMERMAX;
    AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = TIMERMAX;
            aud.pitch = Random.Range(0.01f, 2f);
            aud.PlayOneShot(aud.clip);
        }
	}
}
