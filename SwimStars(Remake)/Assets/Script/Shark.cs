using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;


public class Shark : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private const float Jump_Amount = 100f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();

        }
        


    }
    private void Jump()
        {
        rigidbody2D.velocity = Vector2.up * Jump_Amount;

        }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CMDebug.TextPopupMouse("YER FUCKED!"); 
    }
}
