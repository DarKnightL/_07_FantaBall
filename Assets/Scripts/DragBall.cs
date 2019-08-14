using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBall : MonoBehaviour
{

    private Vector3 currentMousePos;


    void Start()
    {
        
    }


    void Update()
    {
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePos.z = 0;
        this.transform.position = currentMousePos;
    }
}
