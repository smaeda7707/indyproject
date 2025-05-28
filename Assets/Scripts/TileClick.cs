using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TileClick : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(1))
        {
            Debug.Log(hit);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                // Renderer rend = gameObject.GetComponent<Renderer>();
                // Material mat = rend.material;
                // mat.SetColor("Color", Color.yellow);
                hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("Color", Color.yellow);
            }
        }

        
        // Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        // Collider2D[] collidersUnderMouse = new Collider2D[4];
        // int numCollidersUnderMouse = Physics2D.OverlapPoint(mousePos, new ContactFilter2D(), collidersUnderMouse);

        // if (Input.GetMouseButtonDown(1))
        // {
        //     for (int i = 0; i < numCollidersUnderMouse; ++i)
        //     {
        //         if (collidersUnderMouse[i].gameObject.layer == LayerMask.NameToLayer("Ground"))
        //         {
        //             Debug.Log("Clicked");
        //         }
        //     }
        // }
    }
    
}
