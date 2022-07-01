using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    private Animator mAnimation;
    private void Awake()
    {
        mAnimation = GetComponent<Animator>();
        if(!PlayerPrefs.HasKey("StageFinished"))
        {
            PlayerPrefs.SetInt("StageFinished", 0);
        }
    }
    public void Open()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.chestOpen);
        mAnimation.SetBool("tryOpen", true);
    }
    public void ChangeScene()
    {
        BGMController.instance.SaveVolume();
        mAnimation.SetBool("tryOpen", false);
        int curStage = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("StageFinished",Mathf.Max(PlayerPrefs.GetInt("StageFinished"), curStage - 1));
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(curStage + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
