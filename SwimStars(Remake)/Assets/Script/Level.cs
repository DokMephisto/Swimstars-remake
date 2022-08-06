using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float camSize = 50f;
    private const float Mine_Width = 12;
    private const float Mine_Height = 12;
    private const float mineSpeed = 30;
    private const float mineToss = -100f;
    private const float mineSpawn = 100f;


    private List<Mine> minelist;
    private float Timer;
    private float TimerMax;
    private float offset; 

    private void Awake() {

        minelist = new List<Mine>();
        TimerMax = 1.5f;
        offset = 20;

    }

    private void Start() {

        //CreateMine(0, 0);
        //CreateMineOffset(50f, 20f, 20f);
    }


    private void CreateMineOffset(float offsetY, float offsetSize, float xPosition) {

        CreateMine(offsetY - offsetSize * .5f, xPosition);
        CreateMine(camSize * 2f - offsetY - offsetSize * .5f, xPosition);
        
    }

    private void Update() {

        HandleMineMovement();
        HandleMineSpawning();

    }

    private void HandleMineSpawning() {
        Timer -= Time.deltaTime;
        if (Timer < 0) {
            Timer += TimerMax;
             

            float heightEdge = 10f;
            float minHeight = offset + heightEdge;
            float totalHeight = camSize * 2;
            float maxHeight = totalHeight - offset *.5f - heightEdge;

            float height = Random.Range(minHeight, maxHeight);
            CreateMineOffset(height, offset, mineSpawn);
        }
    }

    private void HandleMineMovement() {

        for (int i = 0; i < minelist.Count; i++) {
            Mine mine = minelist[i];
                mine.Move();

                if (mine.GetXPosition() < mineToss) {

                    //destroy mine
                    mine.DestroySelf();
                minelist.Remove(mine);
                i--;
                }

            }
    }
    private void CreateMine(float height,float xPosition){

       Transform mineobj = Instantiate(GameAssets.GetInstance().pfmine);
        mineobj.position = new Vector3(xPosition, 0f);

        SpriteRenderer mineSpriteRenderer = mineobj.GetComponent<SpriteRenderer>();
        mineSpriteRenderer.size = new Vector2(Mine_Width, Mine_Height);

        BoxCollider2D mineCollider = mineobj.GetComponent<BoxCollider2D>();
        mineCollider.size = new Vector2(Mine_Width, Mine_Height);

        Mine mine = new Mine(mineobj);

        minelist.Add(mine);

  
    }

    private class Mine {

        private Transform mineTransform;

        public Mine(Transform mineTransform) {

            this.mineTransform = mineTransform;
        }

        public void Move() {

            mineTransform.position += new Vector3(-1, 0, 0) * mineSpeed * Time.deltaTime;
        }

        public float GetXPosition() {

            return mineTransform.position.x;
        }

        public void DestroySelf() {

            Destroy(mineTransform.gameObject);
        }
    }

    

   
}
