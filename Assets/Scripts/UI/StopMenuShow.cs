using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopMenuShow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Tooltip("交互事件列表。")] private UnityEvent keyDownEvent = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            keyDownEvent.Invoke();
        }
        
    }
}
