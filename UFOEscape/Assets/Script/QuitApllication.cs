using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApllication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quit();
    }

    void Quit(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            Debug.Log("biji nangka");
        }
    }
}
