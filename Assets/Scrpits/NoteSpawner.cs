using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefabs;      // ��Ʈ ������
    public float minXPosition = -2.8f;    // �ּ� x ��ġ
    public float maxXPosition = 2.3f;     // �ִ� x ��ġ
    public float BPM = 120f;            // BPM
    public float beatPerNote = 1.0f;    // �� ��Ʈ�� ���� �� (1���� 2���� 4����)
    public bool startPlaying = false;

    private float beatInterval;         // �� ��Ʈ ����
    private float timer = 0;
    private int beatCount = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = BPM / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
            }
        }

        else
        {
            timer += Time.deltaTime;

            if (timer >= beatInterval)
            {
                beatCount++;

                if (beatCount % beatPerNote == 0)
                {
                    SpawnNote();
                }
                timer = 0;
            }
        }

    }

    void SpawnNote()
    {
        float randomXPosition = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y, transform.position.z);

        GameObject newNote = Instantiate(notePrefabs, spawnPosition, Quaternion.identity);
    }
}
