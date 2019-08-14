using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public int colorIndex;

    public int basketState;//0 empty; 1 colormatch; -1 colorNOTmatch; -2 More than 1 ball

    public int pileIndex;
    private int exitBallNum;

    private PolygonCollider2D selfPolygonCollider2D;


    void Start()
    {
        basketState = 0;
        exitBallNum = 0;
        selfPolygonCollider2D = GetComponent<PolygonCollider2D>();
        PolygonColliderJudge();
    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PhysicsBall") && selfPolygonCollider2D.enabled == true)
        {

            if (basketState == 0)
            {
                PhysicsBall tempPhysicsBall = col.transform.GetComponent<PhysicsBall>();
                if (this.colorIndex == tempPhysicsBall.colorIndex)
                {
                    basketState = 1;
                }
                else
                {
                    basketState = -1;
                }



            }
            else basketState = -2;
        }

        LevelController.instance.GameStateRefresh();
    }



    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer==LayerMask.NameToLayer("PhysicsBall"))
        {
            exitBallNum++;
            PolygonColliderJudge();
        }
    }



    private void PolygonColliderJudge()
    {

        selfPolygonCollider2D.enabled = (exitBallNum >= pileIndex);
    }

}
