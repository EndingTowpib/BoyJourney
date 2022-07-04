using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public AnimationCurve myCurve;
    private bool flag = false;//判定角色是否进入范围
    public float intialY = 1;//初始位置，设为与放置的物体的初始Y坐标相同
    [SerializeField] [Tooltip("可交互的标签。")] private string reactTag = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == reactTag)
        {
            this.flag = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == reactTag)
    //    {
    //        this.flag = false;
    //    }
    //}
    void Start()
    {
        
    }

    void Update()
    {
        if(flag)
        {
            transform.position = new Vector3(transform.position.x, intialY*myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
            //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
        }
    }
}