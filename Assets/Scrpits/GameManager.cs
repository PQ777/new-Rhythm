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
    public int perfectHitNoteSum = 0;
    public int goodHitNoteSum = 0;
    public int missNoteSum = 0;

    public int scorePerNote = 1;
    public Text scoreText;
    public Text perfectHitSum;
    public Text goodHitSum;
    public Text missSum;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        //audioSource = GetComponent<AudioSource>();
        //hitAudioSource = GetComponent<AudioSource>();

        scoreText.text = "0";
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
        GoodHitNoteSum();
    }

    public void PerfectHit()
    {
        Debug.Log("Perfect");
        hitAudioSource.Play();

        currentScore += (scorePerNote * 2);
        PerfectHitNoteSum();


    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        //missAudioSource.Play();
    }

    public void HitScoreText()
    {
        scoreText.text = "" + currentScore;
    }

    public void PerfectHitNoteSum()
    {
        perfectHitNoteSum += 1;
        perfectHitSum.text = "" + perfectHitNoteSum;
    }

    public void GoodHitNoteSum()
    {
        goodHitNoteSum += 1;
        goodHitSum.text = "" + goodHitNoteSum;
    }

    public void MissNoteSum()
    {
        missNoteSum += 1;
        missSum.text = "" + missNoteSum;
    }

}
