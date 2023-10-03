using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoTroop : MonoBehaviour
{
    public KeyCode removalKey = KeyCode.E; // Change this key to the one you want
    private bool isVisible = true;

    private void Update()
    {
        if (Input.GetKey(removalKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    // Check if the clicked object has a collider
                    GameObject clickedObject = hit.collider.gameObject;
                    // Optionally, add conditions here to determine if the object should be removed
                    clickedObject.SetActive(false); // Remove the object
                }
            }
        }
    }
}
