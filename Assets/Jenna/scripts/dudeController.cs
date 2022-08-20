using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudeController : MonoBehaviour
{
    public float walkSpeed;

    public SpriteRenderer dudeSprite;


    public Rigidbody2D dudeBody;

    public Animator dudeAnimator;

     float movement = 0f;

    public GameObject characterSelectionManager;

    
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
            Debug.Log("flip true");
            dudeSprite.flipX = true;
        }
        else
       if (dudeSprite.flipX && movement> 0)
        {
            Debug.Log("flip false");
            dudeSprite.flipX = false;
        }
    }
}
