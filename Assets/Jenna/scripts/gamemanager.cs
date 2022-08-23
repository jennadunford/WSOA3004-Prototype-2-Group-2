using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject chains1;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void liftChains(GameObject chain)
    {
        chain.gameObject.transform.position = new Vector2(chain.gameObject.transform.position.x, chain.gameObject.transform.position.y + 0.5f);
    }
}
