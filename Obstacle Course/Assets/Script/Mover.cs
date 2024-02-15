using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float Movespeed ;
    //[SerializeField] float yvalue ;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void PrintInstruction(){
        Debug.Log("Welcome To The Game");
        Debug.Log("Avoid all Obstacle ");
        Debug.Log("dont hit the Wall");
    }
    void MovePlayer(){
        float xvalue = Input.GetAxis("Horizontal")*Time.deltaTime*Movespeed;
        float zvalue = Input.GetAxis("Vertical")*Time.deltaTime*Movespeed;
        
        transform.Translate(xvalue,0,zvalue);
    }
}
