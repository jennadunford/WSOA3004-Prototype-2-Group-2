using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderController : MonoBehaviour
{
    public float spiderSpeed;

    public SpriteRenderer spiderSprite;


    public Rigidbody2D spiderBody;

    public Animator spiderAnimator;

    float movement = 0f;

    bool onWall = false;

    public GameObject characterSelectionManager;
    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    private void FixedUpdate()
    {
        if (characterSelectionManager.GetComponent<characterSelectionManager>().spiderSelected)
            if(!onWall)
            {
                
                movement = Input.GetAxisRaw("Horizontal");
                spiderBody.velocity = new Vector2(movement * spiderSpeed, spiderBody.velocity.y);
                spiderAnimator.SetFloat("spiderVelocity", Mathf.Abs(movement));
                flip();
            }
            else if (onWall)
            {
                movement = Input.GetAxisRaw("Vertical");
                spiderBody.velocity = new Vector2(spiderBody.velocity.x, movement * spiderSpeed);
                spiderAnimator.SetFloat("spiderVelocity", Mathf.Abs(movement));
                flip();
            }

    }

    void flip()
    {
        if (!spiderSprite.flipX && movement < 0)
        {
            Debug.Log("flip true");
            spiderSprite.flipX = true;
        }
        else
       if (spiderSprite.flipX && movement > 0)
        {
            Debug.Log("flip false");
            spiderSprite.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * 90;
        if (collision.gameObject.tag == "rightWall")
        {
            onWall = true;
            spiderBody.gravityScale = 0;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * -90;
        if (collision.gameObject.tag == "rightWall")
        {
            spiderBody.gravityScale = 1;
            onWall = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
    }
}
