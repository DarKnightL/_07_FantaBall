using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBar : MonoBehaviour
{

    public int colorIndex;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer==LayerMask.NameToLayer("PhysicsBall"))
        {
            col.gameObject.GetComponent<PhysicsBall>().colorIndex = this.colorIndex;
            col.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        }
    }
}
