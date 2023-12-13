using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyImage;
    public GameObject hasKey;
    public GameObject handUI;
    public bool isPlayer;
    public AudioSource source;
    public GameObject findHatchPrompt;
    public GameObject key;

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
        if (hasKey.activeSelf == true) 
        {

        }
        else if(isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                keyImage.SetActive(true);
                hasKey.SetActive(true);
                handUI.SetActive(false);
                source.Play();
                findHatchPrompt.SetActive(true);

                Invoke("RemoveHatchPrompt", 2);
                key.SetActive(false);
            }
        }
    }

    void RemoveHatchPrompt()
    {
        findHatchPrompt.SetActive(false);
        Destroy(gameObject);
    }
}
