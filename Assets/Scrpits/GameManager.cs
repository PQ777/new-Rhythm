using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public NoteSpawner startNote;
    public AudioSource audioSource;
    public AudioSource hitAudioSource;
    public AudioSource missAudioSource;

    public int scorePerNote = 100;
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
        if(!startNote)
        {
            if(Input.anyKeyDown)
            {
                startNote.startPlaying = true;
            }
        }
    }

    public void PlayMusic()
    {
        //audioSource.playOnAwake = true;
        audioSource.Play();
    }

    public void NoteHit()
    {
        Debug.Log("Hit");
        hitAudioSource.Play();
        
    }

    public void GoodHit()
    {

    }

    public void PerfectHit()
    {

    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        //missAudioSource.Play();
    }


}
