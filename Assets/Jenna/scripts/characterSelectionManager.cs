using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSelectionManager : MonoBehaviour
{
    public bool dogSelected = false;
    public bool spiderSelected = false;
    public bool dudeSelected = false;
    public bool ghostSelected = true;

    public Text selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    public void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            switch (hit.collider.gameObject.name)
            {
                case "dog":
                    selectDog();
                    Debug.Log("Dog is selected");
                    selectedCharacter.text = "Selected: Dog";
                    break;
                case "dude":
                    selectDude();
                    Debug.Log("Dude is selected");
                    selectedCharacter.text = "Selected: Dude";
                    break;
                case "ghost":
                    selectGhost();
                    Debug.Log("Ghost is selected");
                    selectedCharacter.text = "Selected: Ghost";
                    break;
                case "spider":
                    Debug.Log("spider is selected");
                    selectedCharacter.text = "Selected: Spider";
                    selectSpider();
                    break;
            }
        }
    }

    public void selectDog()
    {
        dogSelected     = true;
        spiderSelected  = false;
        dudeSelected    = false;
        ghostSelected   = false;
}

    public void selectSpider()
    {
        dogSelected     = false;
        spiderSelected  = true;
        dudeSelected    = false;
        ghostSelected   = false;
    }

    public void selectDude()
    {
        dogSelected     = false;
        spiderSelected  = false;
        dudeSelected    = true;
        ghostSelected   = false;
    }

    public void selectGhost()
    {
        dogSelected     = false;
        spiderSelected  = false;
        dudeSelected    = false;
        ghostSelected   = true;
    }


}
