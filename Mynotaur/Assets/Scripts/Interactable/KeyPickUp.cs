using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyImage;
    public GameObject hasKey;
    public GameObject handUI;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = false;
            handUI.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                keyImage.SetActive(true);
                hasKey.SetActive(true);
                handUI.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
