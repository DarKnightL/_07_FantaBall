using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public float[] angleArray;

    private int currentAngleIndex;

    private RaycastHit2D hitInfo2D;
    private int hitMask;


    void Start()
    {
        currentAngleIndex = 0;

        hitMask += 1 << LayerMask.NameToLayer("Bottle");
    }



    void Update()
    {
        if (MyClass.currentGameState == GameState.Playing && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (this.GetComponent<BoxCollider2D>().OverlapPoint(mousePos))
            {
                hitInfo2D = Physics2D.Raycast(mousePos, Vector3.forward, Camera.main.farClipPlane);
                if (hitInfo2D)
                {
                    currentAngleIndex = (currentAngleIndex + 1) % angleArray.Length;
                    this.transform.eulerAngles = Vector3.forward * angleArray[currentAngleIndex];
                }
            }
        }
    }
}
