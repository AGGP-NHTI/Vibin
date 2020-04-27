using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Options;
    public AudioClip select;
    public AudioClip goback;
    public AudioSource source;

    public Slider slider;
    public Slider slider2;

    public AudioSource audioSource;

    void Start()
    {
        slider2.value = PlayerPrefs.GetFloat("Effects", 0.5f);
        slider.value = PlayerPrefs.GetFloat("Music", 0.5f);
    }
   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ToOptions()
    {
        source.PlayOneShot(select, PlayerPrefs.GetFloat("Effects"));
        Main.SetActive(false);
        Options.SetActive(true);
    }
    public void ToMain()
    {
        source.PlayOneShot(goback, PlayerPrefs.GetFloat("Effects"));
        Main.SetActive(true);
        Options.SetActive(false);
    }
    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("Music", slider.value);
        PlayerPrefs.Save();
        audioSource.volume = PlayerPrefs.GetFloat("Music");
    }
    public void ChangeEffectVolume()
    {
        PlayerPrefs.SetFloat("Effects", slider2.value);
        PlayerPrefs.Save();
    }
}
