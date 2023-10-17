using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentLine : MonoBehaviour
{
    public AudioSource hitAudioSource;
    public bool canBeHit = false;
    // Start is called before the first frame update
    void Start()
    {
        hitAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Note" && !canBeHit)
        {

        }
    }
}

// C:\Users\dlsgh\AppData\Local\osu!\Skins\1. o2jam New
