using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginUIChange : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void ExitGame()
    {
        //BGMController.instance.SaveVolume();
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
