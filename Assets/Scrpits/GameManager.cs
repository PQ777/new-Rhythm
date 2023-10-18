using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public NoteSpawner startNote;
    public AudioSource audioSource;
    public AudioSource hitAudioSource;
    public AudioSource missAudioSource;
    public float timeScaleBeforePause;


    public int currentScore;
    public int scorePerNote = 1;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        //audioSource = GetComponent<AudioSource>();
        //hitAudioSource = GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!startNote)
        {
            if (Input.anyKeyDown)
            {
                startNote.startPlaying = true;
            }
        }

    }

    public void PauseGame()
    {
        timeScaleBeforePause = Time.timeScale;
         Time.timeScale = 0;
        startNote.startPlaying = false;
   
    }

    //public void ResumeGame()
    //{

    //    Time.timeScale = timeScaleBeforePause;
    //    startNote.startPlaying = true;
    //    SceneManager.LoadScene("SampleScene");

    //}

    public void PlayMusic()
    {
        //audioSource.playOnAwake = true;
        audioSource.Play();
    }

    public void NoteHitScreen()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void MainBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //public void NoteHit()
    //{
    //    Debug.Log("Hit");
    //    hitAudioSource.Play();
        
    //}

    public void GoodHit()
    {
        Debug.Log("Good");
        hitAudioSource.Play();

        currentScore += scorePerNote;
        NoteHitScreen();
    }

    public void PerfectHit()
    {
        Debug.Log("Perfect");
        hitAudioSource.Play();

        currentScore += (scorePerNote * 2);
        NoteHitScreen();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        //missAudioSource.Play();
    }



}
