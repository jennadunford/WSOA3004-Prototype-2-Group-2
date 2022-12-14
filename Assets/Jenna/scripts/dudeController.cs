using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudeController : MonoBehaviour
{

    public GameObject doorOpen;
    public GameObject doorClosed;
    public GameObject hoverLight;
    public float walkSpeed;

    public SpriteRenderer dudeSprite;


    public Rigidbody2D dudeBody;

    public Animator dudeAnimator;

     float movement = 0f;

    public GameObject characterSelectionManager;

    public bool dudeSafe = false;

    
    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (characterSelectionManager.GetComponent<characterSelectionManager>().dudeSelected)
        {
            movement = Input.GetAxisRaw("Horizontal");

            dudeBody.velocity = new Vector2(movement * walkSpeed, dudeBody.velocity.y);
            dudeAnimator.SetFloat("dudeVelocity", Mathf.Abs(movement));
            flip();
        }
            
    }

    void flip()
    {
        if (!dudeSprite.flipX && movement < 0)
        {
            //Debug.Log("flip true");
            dudeSprite.flipX = true;
        }
        else
       if (dudeSprite.flipX && movement> 0)
        {
            //Debug.Log("flip false");
            dudeSprite.flipX = false;
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

    public void openDoor()
    {
        doorOpen.SetActive(true);
        doorClosed.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "door") openDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "fire":
                dudeSafe = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "fire":
                dudeSafe = false;
                break;


        }
    }
}
