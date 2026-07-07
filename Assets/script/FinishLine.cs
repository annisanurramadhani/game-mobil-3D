using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;
    public Timer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.StopTimer();

            winPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}