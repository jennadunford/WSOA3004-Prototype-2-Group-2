using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    public ParticleSystem barkParticles;
    // Start is called before the first frame update
    void Start()
    {
        barkParticles = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
            if(other.gameObject.tag == "evilGhost")
        {
            Destroy(other.gameObject);

        }
    }
}
