using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2 : MonoBehaviour
{
    public float speed = 2.0f;
    public bool canBePressed = false;
    public KeyCode keyToPress1, keyToPress2;
    public bool canBeMusicPlay = false;
    public GameObject perfectEffect, goodEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(!canBePressed)
        {
            if (transform.position.y < -4.5f)
            {
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameManager.instance.MissNoteSum();
            }
        }
            

        if(Input.GetKeyDown(keyToPress1) || Input.GetKeyDown(keyToPress2))
        {
            if(canBePressed)
            {

                if(transform.position.y >= -3.6f || transform.position.y <= -3.7f)
                {
                    GameManager.instance.GoodHit();
                    GameManager.instance.ScoreNoteSum();
                    Instantiate(goodEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }

                else
                {
                    GameManager.instance.PerfectHit();
                    GameManager.instance.ScoreNoteSum();
                    Instantiate(perfectEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }

                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "JudgmentLine")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "JudgmentLine")
        {
            canBePressed = false;

        }
    }


}
