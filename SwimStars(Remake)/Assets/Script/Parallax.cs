using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private MeshRenderer mesh;

    public float speed = 1f;

    private void Awake() {

        mesh = GetComponent<MeshRenderer>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
