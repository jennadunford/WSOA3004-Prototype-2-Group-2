using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject hoverLight;
    public float floatSpeed;

    public SpriteRenderer ghostSprite;

    Vector2 direction;

    public Rigidbody2D ghostBody;

    public GameObject characterSelectionManager;

    public bool ghostSafe = false;


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
        else
        {
            ghostBody.transform.position = new Vector3(cameraObject.GetComponent<cameraFollow>().players[characterSelectionManager.GetComponent<characterSelectionManager>().chosenCharacter].transform.position.x - 1, cameraObject.GetComponent<cameraFollow>().players[characterSelectionManager.GetComponent<characterSelectionManager>().chosenCharacter].transform.position.y + 1.3f,0);
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
                ghostSafe = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "fire":
                ghostSafe = false;
                break;


        }
    }
}
