using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIChange : MonoBehaviour
{
    private GameObject UI_Pause;
    private bool isPause;
    private void Awake()
    {
        UI_Pause = transform.GetChild(0).gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        UI_Pause.SetActive(false);
        isPause = false;
    }
    public void ChangePauseStatus()
    {
        if(isPause)
        {
            DePause();
            isPause = false;
        }
        else
        {
            Pause();
            isPause = true;
        }
    }
    public void Pause()
    {
        UI_Pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void DePause()
    {
        UI_Pause.SetActive(false);
        Time.timeScale = 1;
    }

}
