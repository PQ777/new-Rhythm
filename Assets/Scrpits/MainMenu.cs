using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource mainMenuClick;

    public void StartGame()
    {
        mainMenuClick.Play();
        SceneManager.LoadScene("SongSelect");
    }

    public void Option()
    {
        mainMenuClick.Play();
        SceneManager.LoadScene("Option");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
