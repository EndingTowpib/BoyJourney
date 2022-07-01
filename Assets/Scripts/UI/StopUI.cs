using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Character;
public class StopUI : MonoBehaviour
{
    public void Replay()
    {
        BGMController.instance.SaveVolume();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        BGMController.instance.SaveVolume();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
