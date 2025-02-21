using UnityEngine;
using TMPro;

public class PlayerDestroy : MonoBehaviour
{
    public TMP_Text scoreText; // Assign this in the Unity Inspector
    private int points = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            BreakableObject breakable = other.GetComponent<BreakableObject>();
            if (breakable != null)
            {
                points += breakable.pointValue; // Add the object's points
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                rb.AddForce(Vector3.up*500f);
                rb.AddTorque(50f);
                UpdateScoreText(); // Update UI
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "You're a cat. Break as much stuff as you can. Score: " + points;
        }
    }
  
}
