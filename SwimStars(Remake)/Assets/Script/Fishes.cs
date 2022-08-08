using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishes : MonoBehaviour {

    public float speed = 5f;
    private float edge;


    // Start is called before the first frame update
    void Start() {
        edge = Camera.main.ScreenToWorldPoint(Vector2.zero).x - 5f;
    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < edge) {

            Destroy(gameObject);
        }
    }
}
