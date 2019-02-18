using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool gameOver { get; set; }
    public Text gameOverText;
    public Text restartText;
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
        gameOver = false;
        StartCoroutine( SpawnWaves());
    }
    public void AddScore(int newScoreValue){
        score+=newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
    }
    void UpdateScore(){
        scoreText.text="Score:"+score;
    }
    
    IEnumerator SpawnWaves()
    {
        for(;!gameOver;)
        {
            spawnPosition.x=Random.Range(-spawnValues.x,spawnValues.x);
            spawnPosition.z=spawnValues.z;
            spawnRotation = Quaternion.identity;
            Instantiate(hazard,spawnPosition,spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
        this.restartText.text = "Press [R] to restart";
        this.gameOverText.text = "Game Over";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
