using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private GameObject trapDoor0;
    private GameObject trapDoor1;

    void Start()
    {
        trapDoor0 = this.transform.GetChild(0).gameObject;
        trapDoor1 = this.transform.GetChild(1).gameObject;
    }


    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer==LayerMask.NameToLayer("PhysicsBall"))
        {
            trapDoor0.SetActive(!trapDoor0.activeSelf);
            trapDoor1.SetActive(!trapDoor1.activeSelf);
        }
    }
}
