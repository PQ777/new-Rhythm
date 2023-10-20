using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefabs;      // ��Ʈ ������
    public float minXPosition = -2.8f;    // �ּ� x ��ġ
    public float maxXPosition = 2.3f;     // �ִ� x ��ġ
    public float BPM = 120f;            // BPM
    public float beatPerNote = 1.0f;    // �� ��Ʈ�� ���� �� (1���� 2���� 4����)
    public bool startPlaying = false;
    public float spawnOffset = 1.0f;
    public int desiredNoteCount = 50;
    public int totalNoteSpawned = 0;
    //public bool firstStart = false;
    public Text howToPlayText;
  

    private float beatInterval;         // �� ��Ʈ ����
    private float timer = 0;
    private int beatCount = 0;

    private float songStartTime;
    private int currentBeat = 4;
   
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = 60f / BPM;
        songStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                howToPlayText.enabled = false;
            }
        }
        else
        {
            float songPosition = Time.time - songStartTime;

            float noteSpawnTime = (currentBeat - 1) * beatInterval;

            Debug.Log(noteSpawnTime);

            if(songPosition > 93f)
            {
                GameManager.instance.PauseGame();
            }

            else if(songPosition >= noteSpawnTime)
            {
                SpawnNote();

                float randomNotePosition = Random.Range(0, 4);
                if(randomNotePosition % 3 == 0)
                {
                    SpawnNote();

                }
                
                currentBeat++;
            }

            //timer += Time.deltaTime;

            //if (timer >= beatInterval)
            //{
            //    beatCount++;

            //    if (beatCount % beatPerNote == 0)
            //    {
            //        SpawnNote();

            //    }
            //    timer = 0;
            //}
        }

        if (startPlaying && Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.PauseGame();
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.instance.RestartGame();
            }

            else if (Input.GetKeyDown(KeyCode.Q))
            {
                GameManager.instance.SelectSongBack();
            }

            //else if(!startPlaying && Input.GetKeyDown(KeyCode.S))
            //{
            //    GameManager.instance.ResumeGame();
            //}





      

        }

        void SpawnNote()
        {

            float randomXPosition = Random.Range(minXPosition, maxXPosition);
            Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y, transform.position.z);

            GameObject newNote = Instantiate(notePrefabs, spawnPosition, Quaternion.identity);

            float randomXposition2 = Random.Range(0, 3);
            if (randomXposition2 % 2 == 0)
            {
                Vector3 spawnPosition2 = spawnPosition + new Vector3(spawnOffset, 0, 0);
                Instantiate(notePrefabs, spawnPosition2, Quaternion.identity);
            }

            totalNoteSpawned++;

        }
    }


