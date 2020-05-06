using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;

    public AudioSource Song;
    public AudioSource lines;
    public AudioSource pausesong;
    public AudioSource boss;
    public AudioSource bosssounds;
    public AudioSource player;

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
        player.mute = true;
        bosssounds.Pause();
        boss.Pause();
        Song.Pause();
        lines.Pause();
        pausesong.Play();
        isPaused = true;
        Menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnUnpause()
    {
        player.mute = false;
        boss.UnPause();
        lines.UnPause();
        pausesong.Stop();
        Song.UnPause();
        isPaused = false;
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
