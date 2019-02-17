using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public float spawnWait;
    public Vector3 spawnValues;
    public Vector3 spawnPosition=Vector3.zero;
    private Quaternion spawnRotation;
    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( SpawnWaves());
    }
    public void AddScore(int newScoreValue){
        score+=newScoreValue;
        UpdateScore();
    }
    void UpdateScore(){
        scoreText.text="Score:"+score;
    }
    
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

    // Update is called once per frame
    void Update()
    {
    
    }
}
