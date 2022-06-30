using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class StopMenuShow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.GameStop)
        {
            transform.Find("quit").gameObject.SetActive(true);
            transform.Find("startBtn").gameObject.SetActive(true);
            transform.Find("restart").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("quit").gameObject.SetActive(false);
            transform.Find("startBtn").gameObject.SetActive(false);
            transform.Find("restart").gameObject.SetActive(false);
        }
        
    }
}
