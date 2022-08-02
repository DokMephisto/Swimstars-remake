using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    int count = 0;
    GameObject mine;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("GameHandler.Start");

        mine = new GameObject("mine", typeof(SpriteRenderer));
        mine.GetComponent<SpriteRenderer>().sprite = GameAssets.GetInstance().mineSprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
