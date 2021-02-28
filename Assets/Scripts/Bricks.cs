using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bricks : MonoBehaviour
{

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                //Debug.Log(selectionRenderer.name); //this was for debugging
                if (selectionRenderer != null && selectionRenderer.name.StartsWith("Brick"))
                {
                    Destroy(selectionRenderer);
                }
            }
        }*/
    }

    
}