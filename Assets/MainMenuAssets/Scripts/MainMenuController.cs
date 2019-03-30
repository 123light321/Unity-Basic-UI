using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

//Put script on Canvas
public class MainMenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Resolution[] _resolutions;
    [SerializeField]
    private Dropdown _resolutionDropdown;

    public void Start()
    {
        resolutionFinder();
    }

    //For Main Menu

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    //For Option Menu

    public void volumeChanger(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("VolumeGame", volume);
    }

    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution newResolution = _resolutions[resolutionIndex];
        Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreen);
    }

    private void resolutionFinder()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        int currentResolution = 0;

        List<string> converted = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++)
        {
            converted.Add(_resolutions[i].width + " X " + _resolutions[i].height);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        //Did the above loop because Dropdown only accepts lists of type 
        _resolutionDropdown.AddOptions(converted);
        _resolutionDropdown.value = currentResolution;
        _resolutionDropdown.RefreshShownValue();
    }


}
