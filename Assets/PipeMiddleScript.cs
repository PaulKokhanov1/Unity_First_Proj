using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Runs whenever object hits the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(logic.gameOverScreen.activeSelf);
        if(collision.gameObject.layer == 6 && logic.gameOverScreen.activeSelf == false)
        {
            logic.addScore(1);
        }
        
    }
}
