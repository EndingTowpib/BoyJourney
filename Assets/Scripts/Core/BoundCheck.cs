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
    public static Vector3 respawn;
    #endregion





    #region ����˽�з���
    /// <summary>
    /// ��һ֡����֮ǰ������
    /// </summary>
    private void Start()
    {
        respawn = new Vector3(-18.0f, 0.0f, 0.0f);
    }

    /// <summary>
    /// ֡ˢ��ʱ������
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// ����ײ����⵽����Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == reactTag)
        {
            ///Debug.Log("ground!!!!");
            UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.charDeath);
            transform.localPosition = respawn;
        }
    
        
    }

    /// <summary>
    /// ����ײ���������Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
     
    }
    #endregion
}


