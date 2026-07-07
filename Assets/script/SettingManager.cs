using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject settingPanel;
    public GameObject exitPanel;

    [Header("Audio Mixer")]
    public AudioMixer mainMixer;

    // =========================
    // PANEL SETTINGS
    // =========================

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    // =========================
    // EXIT PANEL
    // =========================

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

    // =========================
    // AUDIO
    // =========================

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20f);
    }
}