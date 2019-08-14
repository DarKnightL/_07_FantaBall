using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleButton : MonoBehaviour
{
    public int colorIndex;

    private GameObject tempDragBall;
    private Vector3 currentMousePos;

    private int hitMask;
    private RaycastHit2D hitInfo2D;

    void Start()
    {
        hitMask += 1 << LayerMask.NameToLayer("Entrance");
    }


    void Update()
    {

    }


    public void MarbleButtonDown()
    {

        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //currentMousePos.z = 0;
        tempDragBall = Instantiate(Resources.Load<GameObject>("Prefab/DragBall" + colorIndex), currentMousePos, Quaternion.identity) as GameObject;
    }


    public void MarbleButtonUp()
    {
        Destroy(tempDragBall);
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hitInfo2D = Physics2D.Raycast(currentMousePos, Vector3.forward, Camera.main.farClipPlane, hitMask);
        if (hitInfo2D)
        {

            Instantiate(Resources.Load<GameObject>("Prefab/PhysicsBall" + colorIndex), hitInfo2D.transform.position, Quaternion.identity);
        }

        //Ray testRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //bool hitResult = Physics.Raycast(testRay,out hitInfo, Camera.main.farClipPlane, hitMask);
        //if (hitResult)
        //{
        //    Instantiate(Resources.Load<GameObject>("Prefab/PhysicsBall" + colorIndex), hitInfo.transform.position, Quaternion.identity);
        //}

    }

}
