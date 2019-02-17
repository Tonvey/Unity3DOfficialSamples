using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
public GameObject hazard;
    public float spawnWait;
    public Vector3 spawnValues;
    public Vector3 spawnPosition=Vector3.zero;
    private Quaternion spawnRotation;
    
    IEnumerator SpawnWaves()
    {
        for(;;)
        {
            spawnPosition.x=Random.Range(-spawnValues.x,spawnValues.x);
            spawnPosition.z=spawnValues.z;
            spawnRotation = Quaternion.identity;
            Instantiate(hazard,spawnPosition,spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( SpawnWaves());
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
