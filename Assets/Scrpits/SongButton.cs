using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SongButton : MonoBehaviour
{
    public AudioSource songClick;
    public AudioSource backMenu;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SongClick()
    {
        songClick.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void BackMain()
    {
        backMenu.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
