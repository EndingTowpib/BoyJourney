using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public AnimationCurve myCurve;
    private bool flag = false;//�ж���ɫ�Ƿ���뷶Χ
    public float intialY = 1;//��ʼλ�ã���Ϊ����õ�����ĳ�ʼY������ͬ
    [SerializeField] [Tooltip("�ɽ����ı�ǩ��")] private string reactTag = "Player";
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