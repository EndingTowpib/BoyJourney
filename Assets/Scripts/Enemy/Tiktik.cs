using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiktik : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private int index;
    private int x=0;
  
    // Start is called before the first frame update
    void Start()
    {
        index = 1;
 

    }

    // Update is called once per frame
    void Update()
    {
        x -= 10;
        transform.Rotate(new Vector3(0, 0, x), 3f);
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].position, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position,wayPoints[index].position)<=0.05f)
        {
            index++;//Move to the next point
            if(index>wayPoints.Length-1)
            {
                index = 0;
            }
        }
    }
}
