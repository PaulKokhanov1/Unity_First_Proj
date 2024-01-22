using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public MissleSpawnScript missle;
    public bool birdisAlive = true;
    private bool soundEnabled;


    // Start is called before the first frame update
    void Start()
    {
        soundEnabled = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        missle = GameObject.FindGameObjectWithTag("Missle").GetComponent<MissleSpawnScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdisAlive)
        {
            // Vector2.up shorthand for (0, 1)
            myRigidbody.velocity = Vector2.up * flapStrength;
            logic.flapFX.Play();

        }
        shoot();

        if(transform.position.y < -18 || transform.position.y > 19)
        {
            logic.gameOver();
            birdisAlive=false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (soundEnabled) {
            logic.hitFX.Play();
            soundEnabled = false; 
        }
        
        logic.gameOver();
        birdisAlive = false;
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.E) && birdisAlive)
        {
            missle.spawnMissle();

        }
    }
}
