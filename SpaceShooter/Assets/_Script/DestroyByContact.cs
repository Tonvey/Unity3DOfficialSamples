using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("GameController");
        if(go!=null){
            gameController=go.GetComponent<GameController>();
        }else{
            Debug.Log("Can not find GameController object");
        }
        if(gameController==null){
            Debug.Log("Cannot find script GameController.cs");
        }
            
    }
            

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag=="Player")
        {
            Instantiate(playerExplosion,other.transform.position,
                        other.transform.rotation);
            gameController.GameOver();

        }
        else
        {
            gameController.AddScore(scoreValue);
        }
    }
}
