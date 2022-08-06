using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float Mine_Width = 12;
    private const float Mine_Height = 12;
    private const float mineSpeed = 3; 

    private List<Mine> minelist;

    private void Awake() {

        minelist = new List<Mine>();

    }

    private void Start() {

        CreateMine(10f, 0f);
        CreateMine(10f, 0f);
    }

    private void Update() {

        HandleMineMovement();

    }

    private void HandleMineMovement() {

       foreach (Mine mine in minelist) {
            mine.Move();

        }

        
    }
    private void CreateMine(float height, float xPosition){

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
    }

    

   
}
