using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;

    public float timeOffset;
    public Vector2 posOffset;

    [SerializeField]
    float top;

    [SerializeField]
    float bottom;

    [SerializeField]
    float left;

    [SerializeField]
    float right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 start = transform.position;
        Vector3 end = player.transform.position;

        end.x += posOffset.x;
        end.y += posOffset.y;
        end.z = -10;

        transform.position = Vector3.Lerp(start, end, timeOffset * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, left, right), Mathf.Clamp(transform.position.y, bottom, top), transform.position.z);

    }

}
