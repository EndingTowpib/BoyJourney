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

    // Update is called once per frame
    void Update()
    {
        //Trash Code But Only Find This Way To Prevent Chest Gone
        //var scenename = SceneManager.GetActiveScene().name;
        //if (scenename == "Stage1")
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void Open()
    {
        mAnimation.SetBool("tryOpen", true);
    }
    public void ChangeScene()
    {
        mAnimation.SetBool("tryOpen", false);
        SceneManager.LoadScene("SelectScene");
    }
}
