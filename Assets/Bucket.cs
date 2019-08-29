using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float trippingAngleSpeed;
    public float returnAngleSpeed;

    public int bucketCapacity;


    private bool rotateEnabled;

    private int rotateState; //1=before pull out; 2=after pull out

    private float angleCount;

    private int enterBallNum;
    private int exitBallNum;

    private Vector3 originalEulerAngle;


    void Start()
    {
        rotateEnabled = false;
        angleCount = 0;
        originalEulerAngle = this.transform.eulerAngles;
    }


    void Update()
    {
        if (rotateEnabled)
        {
            if (rotateState == 0)
            {
                this.transform.Rotate(Vector3.forward, trippingAngleSpeed * Time.deltaTime);
                angleCount += Mathf.Abs(trippingAngleSpeed * Time.deltaTime);
            }
            if (rotateState==1)
            {
                this.transform.Rotate(Vector3.forward, returnAngleSpeed * Time.deltaTime);
                angleCount -= Mathf.Abs(returnAngleSpeed * Time.deltaTime);
                if (angleCount<=0)
                {
                    rotateEnabled = false;
                    exitBallNum = 0;
                    enterBallNum = 0;
                    angleCount = 0;
                    this.transform.eulerAngles = originalEulerAngle;
                }
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            enterBallNum++;
            if (enterBallNum == bucketCapacity)
            {
                rotateEnabled = true;
                rotateState = 0;
                col.attachedRigidbody.gravityScale = 2f;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer==LayerMask.NameToLayer("PhysicsBall"))
        {
            exitBallNum++;
            if (exitBallNum==bucketCapacity)
            {
                rotateEnabled = true;
                rotateState = 1;
            }
        }
    }
}
