using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 20;
    public float openSpeed = 3;
    public float deadZone = -40;
    public bool enableOpening = false;
    public GameObject pipe;
    public Transform topPipe;
    private float old_pos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pipe created");
        //need to find out how to get child game object
        topPipe = pipe.transform.Find("Top Pipe");
        old_pos = topPipe.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {

            Debug.Log("Panel Destroyed");
            Destroy(gameObject);
        }

        if (topPipe.transform.position.y < old_pos + 15 && enableOpening)
        {
            topPipe.transform.position += (Vector3.up * openSpeed) * Time.deltaTime;
        }
        
    }
}
