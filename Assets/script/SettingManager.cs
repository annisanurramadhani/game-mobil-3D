using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject exitPanel;
    public AudioMixer mainMixer;

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void OpenExit()
    {
        exitPanel.SetActive(true);
    }

    public void CloseExit()
    {
        exitPanel.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}