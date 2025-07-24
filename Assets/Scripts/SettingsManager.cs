using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;
    public TMP_Dropdown colorDropdown;
    public Image backgroundImage;

    private void Start()
    {
        // Load saved settings
        musicToggle.isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        colorDropdown.value = PlayerPrefs.GetInt("BGColor", 0);
        ApplyBackgroundColor(colorDropdown.value);

        // Listeners
        musicToggle.onValueChanged.AddListener(delegate { ToggleMusic(); });
        sfxToggle.onValueChanged.AddListener(delegate { ToggleSFX(); });
        colorDropdown.onValueChanged.AddListener(delegate { ChangeColor(); });
    }

    public void ToggleMusic()
    {
        PlayerPrefs.SetInt("Music", musicToggle.isOn ? 1 : 0);
        // You can play/pause music here using AudioSource if added
    }

    public void ToggleSFX()
    {
        PlayerPrefs.SetInt("SFX", sfxToggle.isOn ? 1 : 0);
        // Control SFX AudioSources later
    }

    public void ChangeColor()
    {
        PlayerPrefs.SetInt("BGColor", colorDropdown.value);
        ApplyBackgroundColor(colorDropdown.value);
    }

    void ApplyBackgroundColor(int index)
    {
        if (backgroundImage == null) return;

        Color color = Color.white;
        switch (index)
        {
            case 0: color = Color.white; break;
            case 1: color = Color.cyan; break;
            case 2: color = Color.magenta; break;
            case 3: color = Color.gray; break;
        }
        backgroundImage.color = color;
    }
}
