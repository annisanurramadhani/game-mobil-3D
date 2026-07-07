using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public mobil playerController;
    public Timer timer;

    IEnumerator Start()
    {
        // Mobil tidak bisa dikendalikan saat countdown
        playerController.enabled = false;

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "GO!";

        // Aktifkan mobil
        playerController.enabled = true;

        // Mulai timer
        timer.StartTimer();

        yield return new WaitForSeconds(1);

        // Sembunyikan countdown
        countdownText.gameObject.SetActive(false);
    }
}