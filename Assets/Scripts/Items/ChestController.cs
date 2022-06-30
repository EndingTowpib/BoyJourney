using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    private Animator mAnimation;
    // Start is called before the first frame update
    void Start()
    {
        mAnimation = GetComponent<Animator>();
    }

    public void Open()
    {
        mAnimation.SetBool("tryOpen", true);
    }
    public void ChangeScene()
    {
        mAnimation.SetBool("tryOpen", false);
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
