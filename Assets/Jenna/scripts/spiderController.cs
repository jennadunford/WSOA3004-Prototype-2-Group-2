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

    public GameObject characterSelectionManager;
    // Start is called before the first frame update
    void Start()
    {
        characterSelectionManager = GameObject.FindGameObjectWithTag("manager");
    }

    private void FixedUpdate()
    {
        if (characterSelectionManager.GetComponent<characterSelectionManager>().spiderSelected)
        {
            movement = Input.GetAxisRaw("Horizontal");

            spiderBody.velocity = new Vector2(movement * spiderSpeed, spiderBody.velocity.y);
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
}
