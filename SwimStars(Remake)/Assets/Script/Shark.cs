using UnityEngine;

public class Shark : MonoBehaviour
{

    private SpriteRenderer shark;
    public Sprite[] sharks;
    private int sharkIndex; 

    private Vector3 direction;
    public float gravity = -9.8f;
    public float antiGravity = 5f;


    private void Awake() {

        shark = GetComponent<SpriteRenderer>();


    }

    private void Start() {

        InvokeRepeating(nameof(AnimateSprite), .05f, .05f);


    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * antiGravity;

        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() {

        sharkIndex++;
        
        if (sharkIndex >= sharks.Length) {

            sharkIndex = 0;
        }

        shark.sprite = sharks[sharkIndex];


    }
}
