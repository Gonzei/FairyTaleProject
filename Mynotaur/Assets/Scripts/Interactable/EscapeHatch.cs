using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeHatch : MonoBehaviour
{
    public GameObject handUI;
    public GameObject hasKey;
    public bool isPlayer;
    public AudioSource source;
    public GameObject findKeyPrompt;

    public string sceneName;

    public LevelChanger levelChanger;
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
                    levelChanger.FadeToLevel(sceneName);
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
        else if (hasKey.activeSelf == false && Input.GetKeyDown(KeyCode.E))
        {
            source.Play();
            findKeyPrompt.SetActive(true);

            Invoke("RemoveLockedWarning", 2);
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

    void RemoveLockedWarning()
    {
        findKeyPrompt.SetActive(false);
    }
}
