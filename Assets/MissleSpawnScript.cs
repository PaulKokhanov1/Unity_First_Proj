using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpawnScript : MonoBehaviour
{
    public GameObject missle;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnMissle()
    {

        Instantiate(missle, new Vector3(bird.transform.position.x + 5, bird.transform.position.y, 0), transform.rotation);

    }
}
