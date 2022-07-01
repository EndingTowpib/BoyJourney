using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] [Tooltip("��ǰ�ء�")] private int curStage = 0;
    [SerializeField] [Tooltip("��ʼͼƬ��")] private Sprite firstSprite = null;
    [SerializeField] [Tooltip("ͨ��ͼƬ��")] private Sprite finishedSprite = null;
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
