using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int SpriteIndex; 

    private Vector3 direction;
    public float gravity = -9.8f;
    public float antiGravity = 5f;


    private void Awake() {

        spriteRenderer = GetComponent<SpriteRenderer>();


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

        SpriteIndex++;
        
        if (SpriteIndex >= sprites.Length) {

            SpriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[SpriteIndex];

    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Obstacle") {

            FindObjectOfType<Gamemanager>().GameOver();
        } else if (other.gameObject.tag == "Score") {

            FindObjectOfType<Gamemanager>().IncreaseScore();
        }

    }
}
