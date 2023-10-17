using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 2.0f;
    public bool canBePressed = false;
    public KeyCode keyToPress;
    public bool canBeMusicPlay = false;
    public GameObject sparkEffect;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

 
            if (transform.position.y < -5.6f)
            {
                GameManager.instance.NoteMissed();
                Destroy(gameObject);
            }
        


        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                GameManager.instance.NoteHit();
                Instantiate(sparkEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
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
