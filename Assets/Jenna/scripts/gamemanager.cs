using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public GameObject chains1;
    public GameObject dog;
    public GameObject dude;
    public GameObject ghost;
    public GameObject spider;

    public Text winText;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(spider.GetComponent<spiderController>().spiderSafe && dog.GetComponent<dogController>().dogSafe && dude.GetComponent<dudeController>().dudeSafe && ghost.GetComponent<ghostController>().ghostSafe)
        {
            Debug.Log("You win everyone is safe!");
            winText.gameObject.SetActive(true);
        }
    }
    public void liftChains(GameObject chain)
    {
        chain.gameObject.transform.position = new Vector2(chain.gameObject.transform.position.x, chain.gameObject.transform.position.y + 0.5f);
    }

   
}
