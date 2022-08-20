using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
    public float dogSpeed;

    public SpriteRenderer dogSprite;


    public Rigidbody2D dogBody;

    public Animator dogAnimator;

    float movement = 0f;

    public GameObject characterSelectionManager;
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
        }
        
    }

    void flip()
    {
        if (!dogSprite.flipX && movement < 0)
        {
            Debug.Log("flip true");
            dogSprite.flipX = true;
        }
        else
       if (dogSprite.flipX && movement > 0)
        {
            Debug.Log("flip false");
            dogSprite.flipX = false;
        }
    }
}