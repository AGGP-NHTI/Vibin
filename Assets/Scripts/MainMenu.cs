using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Options;
    public GameObject Credits;
    public AudioClip select;
    public AudioClip goback;
    
    public Slider slider;
    public Slider slider2;
    public Slider slider3;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    void Start()
    {
        if (slider2 != null)
        {
            slider2.value = PlayerPrefs.GetFloat("Effects", 0.5f);
        }
        if (slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        }
        if (slider2 != null)
        {
            slider3.value = PlayerPrefs.GetFloat("Voices", 0.5f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("AtBoss", 0);
        }
    }
   
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
        audioSource2.PlayOneShot(select, PlayerPrefs.GetFloat("Effects"));
        audioSource2.Play();
        Main.SetActive(false);
        Options.SetActive(true);
        audioSource3.Play();
    }
    public void ToCredits()
    {
        audioSource2.PlayOneShot(select, PlayerPrefs.GetFloat("Effects"));
        Main.SetActive(false);
        Credits.SetActive(true);
    }
    public void ToMain()
    {
        audioSource2.Stop();
        audioSource2.PlayOneShot(goback, PlayerPrefs.GetFloat("Effects"));
        audioSource3.Stop();
        Main.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("Music", slider.value);
          
        audioSource.volume = PlayerPrefs.GetFloat("Music");
        PlayerPrefs.Save();
    }
    public void ChangeEffectVolume()
    {
        PlayerPrefs.SetFloat("Effects", slider2.value);
        audioSource2.volume = PlayerPrefs.GetFloat("Effects");
        PlayerPrefs.Save();
    }
    public void ChangeVoiceVolume()
    {
        PlayerPrefs.SetFloat("Voices", slider3.value);
        audioSource3.volume = PlayerPrefs.GetFloat("Voices");
        PlayerPrefs.Save();
    }
    public void Defaults()
    {
        PlayerPrefs.SetFloat("Music", 0.5f);
        PlayerPrefs.SetFloat("Effects", 0.5f);
        PlayerPrefs.SetFloat("Voices", 0.5f);

        slider2.value = PlayerPrefs.GetFloat("Effects");
        slider.value = PlayerPrefs.GetFloat("Music");
        slider3.value = PlayerPrefs.GetFloat("Voices");

        audioSource.volume = PlayerPrefs.GetFloat("Music");
        audioSource2.volume = PlayerPrefs.GetFloat("Effects");

        PlayerPrefs.Save();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
