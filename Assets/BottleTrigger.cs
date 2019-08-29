using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTrigger : MonoBehaviour
{
    // Start is called before the first frame update
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
            col.transform.position = this.transform.position;
            col.attachedRigidbody.velocity = 10 * this.transform.up;
        }
    }
}
