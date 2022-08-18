using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    private int score;





    public void IncreaseScore() {

        score++;
        Debug.Log("SCORE!");
    } 

    public void GameOver() {

        FindObjectOfType<SceneSwap>().MoveToScene();
        Debug.Log("Yer Fucked!");
        
    
    }
    


    /* // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }*/
}
