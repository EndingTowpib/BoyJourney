using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] [Tooltip("当前关。")] private int curStage = 0;
    [SerializeField] [Tooltip("初始图片。")] private Sprite firstSprite = null;
    [SerializeField] [Tooltip("通关图片。")] private Sprite finishedSprite = null;
    private void Start()
    {
        if(PlayerPrefs.HasKey("StageFinished"))
        {
            //Debug.Log(PlayerPrefs.GetInt("StageFinished"));
            int curSavedStage = PlayerPrefs.GetInt("StageFinished");
            if(curSavedStage >= curStage)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = finishedSprite;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = firstSprite;
            }
        }
    }
    public void Open()
    {
        BGMController.instance.SaveVolume();
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.chestOpen);
        SceneManager.LoadScene(curStage+1);
    }
}
