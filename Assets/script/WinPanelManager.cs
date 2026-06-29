using UnityEngine;

public class WinPanelManager : MonoBehaviour
{
    public GameObject winPanel;

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}