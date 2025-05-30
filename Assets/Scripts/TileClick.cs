using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TileClick : MonoBehaviour
{
    private GameObject selected;
    void Update()
    {

        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Collider2D[] collidersUnderMouse = new Collider2D[4];
        int numCollidersUnderMouse = Physics2D.OverlapPoint(mousePos, new ContactFilter2D(), collidersUnderMouse);

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < numCollidersUnderMouse; ++i)
            {
                if (collidersUnderMouse[i].gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    Debug.Log("Clicked " + collidersUnderMouse[i].gameObject);
                    if (selected != null)
                    {
                        selected.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                    }
                    selected = collidersUnderMouse[i].gameObject;
                    selected.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                }
            }
        }
    }

    
}
