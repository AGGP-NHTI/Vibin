using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;

    public AudioSource Song;
    public AudioSource pausesong;
    public AudioClip pausemusic;
    public bool isPaused = false;

    void Start()
    {
        Menu.SetActive(false);
        pausesong.volume = PlayerPrefs.GetFloat("Music");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {            
            OnPause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
        }
    }
    public void Resume()
    {
        isPaused = false;
        OnUnpause();
    }
    public void OnPause()
    {
        Song.Pause();
        pausesong.Play();
        isPaused = true;
        Menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnUnpause()
    {
        pausesong.Stop();
        Song.UnPause();
        isPaused = false;
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
