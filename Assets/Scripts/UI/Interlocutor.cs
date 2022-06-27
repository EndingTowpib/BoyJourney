using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����������ࡣ
/// </summary>
public class Interlocutor : MonoBehaviour
{
    #region ���ӱ���
    [SerializeField] [Tooltip("�ɽ����ı�ǩ��")] private string reactTag = "Player";
    [SerializeField] [Tooltip("������ʾģ�����")] private GameObject tipTemplate = null;
    [SerializeField] [Tooltip("�Ƿ�����ظ�������")] private bool repeat = false;
    [SerializeField] [Tooltip("�����¼�������")] private KeyCode keyDownCode = KeyCode.F;
    [SerializeField] [Tooltip("�����¼��б�")] private UnityEvent keyDownEvent = null;
    #endregion

    #region ��Ա����
    private GameObject tip = null;
    #endregion

    #region ���Կ���
    /// <summary>
    /// �Ƿ��Ѿ������˽�����
    /// </summary>
    public bool Finished { get; set; } = false;
    #endregion

    #region ����˽�з���
    /// <summary>
    /// ��һ֡����֮ǰ������
    /// </summary>
    private void Start()
    {
        tip = Instantiate(Resources.Load(tipTemplate.name) as GameObject);
        tip.SetActive(false);
    }

    /// <summary>
    /// ֡ˢ��ʱ������
    /// </summary>
    private void Update()
    {
        if (!tip.activeSelf || Finished)
            return;
        if (Input.GetKeyUp(keyDownCode))
        {
            // ��������
            keyDownEvent.Invoke();
            // �����ظ������������ն���
            if (!repeat)
                Finished = true;
            tip.SetActive(false);
        }
    }

    /// <summary>
    /// ����������⵽����Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Finished)
            return;
        if (collision.tag == reactTag)
            tip.SetActive(true);
    }

    /// <summary>
    /// ���������������Ӵ�ʱ������
    /// </summary>
    /// <param name="collision">��ײ�������</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == reactTag)
            tip.SetActive(false);
    }
    #endregion
}


