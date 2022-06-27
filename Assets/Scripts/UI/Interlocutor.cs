using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 交互者组件类。
/// </summary>
public class Interlocutor : MonoBehaviour
{
    #region 可视变量
    [SerializeField] [Tooltip("可交互的标签。")] private string reactTag = "Player";
    [SerializeField] [Tooltip("交互提示模板对象。")] private GameObject tipTemplate = null;
    [SerializeField] [Tooltip("是否可以重复交互。")] private bool repeat = false;
    [SerializeField] [Tooltip("交互事件按键。")] private KeyCode keyDownCode = KeyCode.F;
    [SerializeField] [Tooltip("交互事件列表。")] private UnityEvent keyDownEvent = null;
    #endregion

    #region 成员变量
    private GameObject tip = null;
    #endregion

    #region 属性控制
    /// <summary>
    /// 是否已经进行了交互。
    /// </summary>
    public bool Finished { get; set; } = false;
    #endregion

    #region 基础私有方法
    /// <summary>
    /// 第一帧调用之前触发。
    /// </summary>
    private void Start()
    {
        tip = Instantiate(Resources.Load(tipTemplate.name) as GameObject);
        tip.SetActive(false);
    }

    /// <summary>
    /// 帧刷新时触发。
    /// </summary>
    private void Update()
    {
        if (!tip.activeSelf || Finished)
            return;
        if (Input.GetKeyUp(keyDownCode))
        {
            // 触发方法
            keyDownEvent.Invoke();
            // 运行重复触发将不回收对象
            if (!repeat)
                Finished = true;
            tip.SetActive(false);
        }
    }

    /// <summary>
    /// 当触发器检测到物理接触时触发。
    /// </summary>
    /// <param name="collision">碰撞物体对象。</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Finished)
            return;
        if (collision.tag == reactTag)
            tip.SetActive(true);
    }

    /// <summary>
    /// 当触发器解除物理接触时触发。
    /// </summary>
    /// <param name="collision">碰撞物体对象。</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == reactTag)
            tip.SetActive(false);
    }
    #endregion
}


