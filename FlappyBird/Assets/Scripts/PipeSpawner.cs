using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize;
    [SerializeField] private float minMaxOffset = 1;
    [SerializeField] private Point point;

    public int divider = 2;

    private Coroutine CR_Spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartSpawn()
    {
        if(CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IESpawn());
        }
    }
    void StopSpawn()
    {
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }
    void SpawnPipe()
    {
        holeSize = Random.Range(2, 4);
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        newPipeUp.gameObject.SetActive(true);

        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        newPipeDown.gameObject.SetActive(true);

        newPipeUp.transform.position += Vector3.up * (holeSize / divider);
        newPipeDown.transform.position += Vector3.down *(holeSize / divider);

        float y = minMaxOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }
    IEnumerator IESpawn()
    {
        while (true)
        {
            if (bird.IsDead())
            {
                StopSpawn();
            }
            SpawnPipe();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
