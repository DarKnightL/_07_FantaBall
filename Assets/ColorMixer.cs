using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    private GameObject firstBall;
    private GameObject secondBall;

    private int firstBallColorIndex;
    private int secondBallColorIndex;
    private int mixColorIndex;

    private int enterBallNum;


    void Start()
    {
        enterBallNum = 0;
    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            enterBallNum++;
            if (enterBallNum == 1)
            {
                col.attachedRigidbody.velocity = Vector2.zero;
                col.attachedRigidbody.gravityScale = 0;
                col.transform.position = this.transform.position;
                firstBall = col.gameObject;
                firstBallColorIndex = firstBall.GetComponent<PhysicsBall>().colorIndex;
            }

            if (enterBallNum == 2)
            {
                col.attachedRigidbody.velocity = Vector2.zero;
                col.attachedRigidbody.gravityScale = 0;
                col.transform.position = this.transform.position;
                secondBall = col.gameObject;
                secondBallColorIndex = secondBall.GetComponent<PhysicsBall>().colorIndex;
                mixColorIndex = MyClass.colorMixTable[firstBallColorIndex, secondBallColorIndex];
                Destroy(secondBall);

                firstBall.GetComponent<PhysicsBall>().colorIndex = mixColorIndex;
                firstBall.GetComponent<SpriteRenderer>().color = Resources.Load<SpriteRenderer>("Prefab/PhysicsBall" + mixColorIndex).color;

                firstBall.GetComponent<Rigidbody2D>().gravityScale = 1;
                enterBallNum = 0;
            }
        }
    }
}
