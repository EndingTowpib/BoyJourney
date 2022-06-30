using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Character;
public class StopUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Replay()
    {
        PlayerController.GameStop = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
