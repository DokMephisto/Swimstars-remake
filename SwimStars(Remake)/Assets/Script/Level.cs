using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private void Start() {

        CreateMine(10f, 0f);
        CreateMine(10f, 20f);
    }
    private void CreateMine(float height, float xPosition){

       Transform mine = Instantiate(GameAssets.GetInstance().pfmine);
        mine.position = new Vector3(xPosition, 0f);
    }
}
