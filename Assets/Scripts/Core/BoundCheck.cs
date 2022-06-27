using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 交互者组件类。
/// </summary>
public class BoundCheck : MonoBehaviour
{
    #region 可视变量
    [SerializeField] [Tooltip("可交互的标签。")] private string reactTag = "Bound";
    ///[SerializeField] [Tooltip("是否可以重复交互。")] private bool repeat = false;

    #endregion





    #region 基础私有方法
    /// <summary>
    /// 第一帧调用之前触发。
    /// </summary>
    private void Start()
    {
  
    }

    /// <summary>
    /// 帧刷新时触发。
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// 当触发器检测到物理接触时触发。
    /// </summary>
    /// <param name="collision">碰撞物体对象。</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == reactTag)
        {
            Debug.Log("ground!!!!");
            transform.localPosition = new Vector3(-18.0f, 0.0f, 0.0f);
        }
    
        
    }

    /// <summary>
    /// 当触发器解除物理接触时触发。
    /// </summary>
    /// <param name="collision">碰撞物体对象。</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
     
    }
    #endregion
}


