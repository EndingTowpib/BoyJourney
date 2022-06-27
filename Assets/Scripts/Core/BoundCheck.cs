using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����������ࡣ
/// </summary>
public class BoundCheck : MonoBehaviour
{
    #region ���ӱ���
    [SerializeField] [Tooltip("�ɽ����ı�ǩ��")] private string reactTag = "Bound";
    ///[SerializeField] [Tooltip("�Ƿ�����ظ�������")] private bool repeat = false;

    #endregion





    #region ����˽�з���
    /// <summary>
    /// ��һ֡����֮ǰ������
    /// </summary>
    private void Start()
    {
  
    }

    /// <summary>
    /// ֡ˢ��ʱ������
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// ����������⵽����Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == reactTag)
        {
            Debug.Log("ground!!!!");
            transform.localPosition = new Vector3(-18.0f, 0.0f, 0.0f);
        }
    
        
    }

    /// <summary>
    /// ���������������Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
     
    }
    #endregion
}


