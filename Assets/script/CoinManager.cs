using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;

            scoreText.text = "Score : " + score;

            Destroy(other.gameObject);
        }
    }
}