using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour {

	// Number of seconds before a combo times out.
	private const float TIME_AMOUNT = 1.2f;
    // Number of seconds between each reduction of combo counter.
    private const float SUBTIME_AMOUNT = 0.06f;

    // A reference to the counter text object.
    private Text counterText;

    public int counter = 0;
	public float timer = TIME_AMOUNT;
	public float subtimer = SUBTIME_AMOUNT;

    private void Awake()
    {
        // Find the Combo Counter GameObject and retrieve its text component.
        counterText = GameObject.Find("ComboCounter").GetComponent<Text>();
        // Start off by making the combo counter invisible, because we have 0 combos when we start the level.
        counterText.enabled = false;
    }

	void Update()
	{
		// If we run out of time...
		if (timer < 0)
		{
			if (counter > 0)
			{
				if (subtimer < 0)
                {
                    // Decrease the counter.
                    --counter;
                    subtimer = SUBTIME_AMOUNT;
                    // If the counter just hit 0...
                    if (counter == 0)
                    {
                        // Hide the counter.
                        counterText.enabled = false;
                    }
                    else
                    {
                        // Update the combo counter text.
                        counterText.text = "COMBO COUNTER: " + counter;
                    }
				}
                else
                {
					subtimer -= Time.deltaTime;
				}
			}
		}
		else
		{
			// Decrease the timer.
			timer -= Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		++counter;
		timer = TIME_AMOUNT;
		subtimer = SUBTIME_AMOUNT;
        // Update the combo counter text.
        counterText.text = "COMBO COUNTER: " + counter;
        // Make the combo counter visible.
        counterText.enabled = true;
    }
}
