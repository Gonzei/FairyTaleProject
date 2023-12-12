using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeHatch : MonoBehaviour
{
    public GameObject handUI;
    public GameObject hasKey;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasKey.activeSelf == true)
        {
            if(isPlayer) 
            { 
                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    handUI.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = false;
            handUI.SetActive(false);
        }
    }
}
