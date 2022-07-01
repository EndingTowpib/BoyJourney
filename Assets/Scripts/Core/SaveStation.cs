using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CheckPointOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ///Debug.Log("checkPoint");
            if (!CheckPointOn.activeSelf)
            {
                UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.goSavepoint);
                BoundCheck.respawn = gameObject.transform.position;
                CheckPointOn.SetActive(true);
            }
        }
    }
}
