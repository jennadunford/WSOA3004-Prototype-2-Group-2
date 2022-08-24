using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderController : MonoBehaviour
{
    public SpriteRenderer lightSwitch;
    bool onSwitch1 = false;
    public GameObject hoverLight;
    public float spiderSpeed;

    public SpriteRenderer spiderSprite;


    public Rigidbody2D spiderBody;

    public Animator spiderAnimator;

    float movement = 0f;

    bool onWall = false;
    bool onWall2 = false;
 

    public GameObject characterSelectionManager;
    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    private void FixedUpdate()
    {

        if(onSwitch1 && Input.GetKeyDown(KeyCode.Return))
        {
            characterSelectionManager.GetComponent<gamemanager>().liftChains(characterSelectionManager.GetComponent<gamemanager>().chains1);
            lightSwitch.flipY = !lightSwitch.flipY;
            Debug.Log("Spider pressed switch 1 - chain 1 lifted up");
        }
        if (characterSelectionManager.GetComponent<characterSelectionManager>().spiderSelected)
            if(!onWall && !onWall2)
            {
                spiderBody.constraints = RigidbodyConstraints2D.None;
                spiderBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; ;

                movement = Input.GetAxisRaw("Horizontal");
                spiderBody.velocity = new Vector2(movement * spiderSpeed, spiderBody.velocity.y);
                spiderAnimator.SetFloat("spiderVelocity", Mathf.Abs(movement));
                flip();
            }
            else if (onWall)
            {
                spiderBody.constraints = RigidbodyConstraints2D.None;
              spiderBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                
              
                movement = Input.GetAxisRaw("Horizontal");
                spiderBody.velocity = new Vector2(spiderBody.velocity.x, movement * spiderSpeed);
                spiderAnimator.SetFloat("spiderVelocity", Mathf.Abs(movement));
                flip();
            }
        if (onWall2)
        {
            spiderBody.constraints = RigidbodyConstraints2D.None;
            spiderBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;


            movement = Input.GetAxisRaw("Horizontal");
            spiderBody.velocity = new Vector2(spiderBody.velocity.x, -movement * spiderSpeed);
            spiderAnimator.SetFloat("spiderVelocity", Mathf.Abs(movement));
            flip();
        }


    }

    void flip()
    {
        if (!spiderSprite.flipX && movement < 0)
        {
            
            spiderSprite.flipX = true;
        }
        else
       if (spiderSprite.flipX && movement > 0)
        {
          
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
        if(collision.gameObject.tag == "leftWall")
        {
            tiltAroundZ = Input.GetAxis("Horizontal") * 90;
            onWall2 = true;
            spiderBody.gravityScale = 0;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
        if (collision.gameObject.tag == "floor")
        {
            Debug.Log("touching floor");
            tiltAroundZ = Input.GetAxis("Horizontal") * 0;
            spiderBody.gravityScale = 1;
            onWall = false;
            onWall2 = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * 0;
        if (collision.gameObject.tag == "rightWall")
        {
            spiderBody.gravityScale = 1;
            onWall = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
        if (collision.gameObject.tag == "leftWall")
        {
            spiderBody.gravityScale = 1;
            onWall2 = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
        }
      
    }
    void OnMouseOver()
    {
        hoverLight.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        hoverLight.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "switch1":
                onSwitch1 = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "switch1":
                onSwitch1 = false;
              
                break;
        }
    }

}
