using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public NoteSpawner startNote;
    public bool strPlaying = false;
    public AudioSource audioSource;
    public AudioSource hitAudioSource;
    public AudioSource missAudioSource;
    public float timeScaleBeforePause;
    public GameObject failMenu;

    public GameObject rankingPanel, canvas;

   
    public float delayMusic = 1.0f;


    public int currentScore;
    public int perfectHitNoteSum = 0;
    public int goodHitNoteSum = 0;
    public int missNoteSum = 0;
    public int scoreNoteSum = 0;
    public int maxCombo = 0;
    public float totalNote = 50;
    public int hpSum = 10;

    public int scorePerNote = 1;
    public Text scoreText;
    public Text perfectHitSum;
    public Text goodHitSum;
    public Text missSum;
    public Text scoreSum;
    public Text maxComboText;
    public Text hpText;
    public GameObject gameOverText;

    // Start is called before the first frame update

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
        //audioSource = GetComponent<AudioSource>();
        //hitAudioSource = GetComponent<AudioSource>();
        scoreText.text = "0";
        hpText.text = "10";
    }

    // Update is called once per frame
    void Update()
    {
        if (!strPlaying)
        {
            if (Input.anyKeyDown)
            {

                strPlaying = true;
                startNote.startPlaying = true;

                PlayMusicDelay();

            }
        }

    }

    void PlayMusicDelay()
    {
        double delayTime = AudioSettings.dspTime + delayMusic;
        audioSource.PlayScheduled(delayTime);
        //audioSource.Play();
    }

    public void PauseGame()
    {
        timeScaleBeforePause = Time.timeScale;
         Time.timeScale = 0;
        startNote.startPlaying = false;

        pauseMenu.SetActive(true);
        
    }

    //public void resultPanel()
    //{
    //    if (perfectHitNoteSum + goodHitNoteSum + missNoteSum < totalNote)
    //    {
    //        PauseGame();
    //    }
    //}

    public void RestartGame()
    {

        Time.timeScale = timeScaleBeforePause;
        startNote.startPlaying = true;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");


    }

    public void SelectSongBack()
    {
        Time.timeScale = timeScaleBeforePause;
        SceneManager.LoadScene("SongSelect");
    }

    public void PlayMusic()
    {
        //audioSource.playOnAwake = true;
        
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
        MaxCombo();
    }

    public void GoodHitNoteSum()
    {
        goodHitNoteSum += 1;
        goodHitSum.text = "" + goodHitNoteSum;
        MaxCombo();
    }

    public void MissNoteSum()
    {
        missNoteSum += 1;
        missSum.text = "" + missNoteSum;

        hpSum -= 1;
        hpText.text = "" + hpSum;
        if(hpSum < 0)
        {
            //rankingPanel.SetActive(false);
            //canvas.SetActive(false);
            //Fail();
            PauseGame();
            gameOverText.SetActive(true);
        }
    }

    public void ScoreNoteSum()
    {
        scoreNoteSum += currentScore;
        scoreSum.text = "" + scoreNoteSum;
    }

    public void MaxCombo()
    {
        maxCombo = perfectHitNoteSum + goodHitNoteSum;
        maxComboText.text = "" + maxCombo;
       
    }

    //public void Fail()
    //{
    //    timeScaleBeforePause = Time.timeScale;
    //    Time.timeScale = 0;
    //    startNote.startPlaying = false;

    //    failMenu.SetActive(true);
    //}
}
