using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{

    public Transform barkPoint;
    public GameObject barkParticles;
    public GameObject hoverLight;

    public float dogSpeed;

    public SpriteRenderer dogSprite;


    public Rigidbody2D dogBody;

    public Animator dogAnimator;

    float movement = 0f;

    public GameObject characterSelectionManager;

    public bool dogSafe = false;
    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    private void FixedUpdate()
    {
        if (characterSelectionManager.GetComponent<characterSelectionManager>().dogSelected)
        {
            movement = Input.GetAxisRaw("Horizontal");

            dogBody.velocity = new Vector2(movement * dogSpeed, dogBody.velocity.y);
            dogAnimator.SetFloat("dogVelocity", Mathf.Abs(movement));
            flip();

            if (Input.GetKey(KeyCode.Return))
            {
                dogAnimator.SetTrigger("bark");
                Instantiate(barkParticles, barkPoint.position,Quaternion.identity);
                
                //dogAnimator.SetTrigger("endBark");

            }
        }
        
    }

    void flip()
    {
        if (!dogSprite.flipX && movement < 0)
        {
            //Debug.Log("flip true");
            dogSprite.flipX = true;
        }
        else
       if (dogSprite.flipX && movement > 0)
        {
            //Debug.Log("flip false");
            dogSprite.flipX = false;
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

            case "fire":
                dogSafe = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "fire":
                dogSafe = false;
                break;


        }
    }
}
