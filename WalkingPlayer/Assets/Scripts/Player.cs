using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public int jumpSpeed;
    public int walkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            body.velocity += jumpSpeed * Vector2.up;
        }

        {//x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if(Input.GetKey(KeyCode.A))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
        }
    }
}
