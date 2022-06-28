using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float RadiusLength;
    public float AngelSpeed;

    private float tempAngel;

    private Vector3 newPosition;

    public Vector3 centerPositon;

    public bool roundItsCenter;

    // Use this for initialization
    void Start()
    {
        if (roundItsCenter)
        {
            centerPositon = transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tempAngel += AngelSpeed * Time.deltaTime; // 

        newPosition.x = centerPositon.x + Mathf.Cos(tempAngel) * RadiusLength;
        newPosition.y = centerPositon.y + Mathf.Sin(tempAngel) * RadiusLength;
        newPosition.z = transform.localPosition.z;

        transform.localPosition = newPosition;
    }

}
