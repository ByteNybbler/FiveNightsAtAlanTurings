// Paul Calande 2016

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    float moveSpeed = 500f;

    Vector3 moveVector = Vector3.down;
    float cutoff;

    private void Awake()
    {
        cutoff = -transform.localScale.y - 50;
    }

	void Update ()
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        // If the laser is underground...
        if (transform.position.y < cutoff)
        {
            // Destroy it.
            Destroy(gameObject);
        }
	}
}
