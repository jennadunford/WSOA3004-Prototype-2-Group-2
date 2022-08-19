using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudeController : MonoBehaviour
{
    public float walkSpeed;

    public SpriteRenderer dudeSprite;

    Vector2 direction;

    public Rigidbody2D dudeBody;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.localPosition;
        flip();
        direction.x += Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        transform.localPosition = direction;
       

    }

    void flip()
    {
        if (!dudeSprite.flipX && direction.x < 0)
        {
            Debug.Log("flip true");
            dudeSprite.flipX = true;
        }
        else
       if (dudeSprite.flipX && direction.x > 0)
        {
            Debug.Log("flip false");
            dudeSprite.flipX = false;
        }
    }
}
