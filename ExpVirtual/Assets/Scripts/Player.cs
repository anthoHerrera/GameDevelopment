using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;
    public Animator anim;

    public float walkingSpeed;
    public float jumpSpeed;

    private void Awake()
    {
        trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // y-axis movement
            body.velocity += jumpSpeed * Vector2.up;
            anim.SetBool("isJump", true);
            
        }

        if (body.velocity.y < 0.01)
        {
            anim.SetBool("isJump", false);
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            { // Rotation around y-axis
                if (speed > 0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                    
                }
                else if (speed < -0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 180, 0);
                    
                }
            }
            anim.SetFloat("Speed", Mathf.Abs(speed));
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Evil")
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Esperar());
            

        }
       
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isDead", false);
    }
}
