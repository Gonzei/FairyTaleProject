using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    KeyCode InventoryKey = KeyCode.Tab;
    [SerializeField] private GameObject Canvas;
    private bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
        isOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InventoryKey))
        {
            Canvas.SetActive(true);
            isOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyUp(InventoryKey))
        {
            Canvas.SetActive(false);
            isOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
