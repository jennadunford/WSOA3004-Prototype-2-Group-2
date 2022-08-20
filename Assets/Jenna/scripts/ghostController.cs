using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour
{
    public float floatSpeed;

    public SpriteRenderer ghostSprite;

    Vector2 direction;

    public Rigidbody2D ghostBody;

    public GameObject characterSelectionManager;


    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (characterSelectionManager.GetComponent<characterSelectionManager>().ghostSelected)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            ghostBody.velocity = direction * floatSpeed;
            flip();

        }

    }



    void flip()
    {
        if (!ghostSprite.flipX && direction.x < 0)
        {
            ghostSprite.flipX = true;
        }
        else
       if (ghostSprite.flipX && direction.x > 0)
        {
            ghostSprite.flipX = false;
        }
    }

}