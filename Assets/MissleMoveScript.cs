using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMoveScript : MonoBehaviour
{

    public float moveSpeed = 2;
    public float deadZone = 40;
    private PipeMoveScript parentobject;
    public PipeMoveScript pipeMove;
    // Start is called before the first frame update
    void Start()
    {
        pipeMove = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeMoveScript>();

        GameObject bird = GameObject.FindGameObjectWithTag("Bird");
        Physics2D.IgnoreCollision(bird.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.right * moveSpeed) * Time.deltaTime;

        if (transform.position.x > deadZone)
        {

            //Debug.Log("Missle Destroyed");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Spring")
        {
            //add logic to open pipes up
            Debug.Log("Missle Collisionwith Spring");
            parentobject = collision.gameObject.transform.parent.gameObject.GetComponent<PipeMoveScript>();
            parentobject.enableOpening = true;

        } else
        {
            
            Debug.Log("Missle Collision");
        }
        Destroy(gameObject);

    }
}
