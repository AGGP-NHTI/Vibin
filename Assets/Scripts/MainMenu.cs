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
    float mspot;
    bool off = false;
    public Slider slider;
    public Slider slider2;
    public Slider slider3;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    void Start()
    {
        slider2.value = PlayerPrefs.GetFloat("Effects", 0.5f);
        slider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        slider3.value = PlayerPrefs.GetFloat("Voices", 0.5f);
    }
   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void FixedUpdate()
    {
       
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
        Main.SetActive(false);
        Options.SetActive(true);
    }
    public void ToMain()
    {
        audioSource2.PlayOneShot(goback, PlayerPrefs.GetFloat("Effects"));
        Main.SetActive(true);
        Options.SetActive(false);
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
    
}
