using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TileClick : MonoBehaviour
{
    private GameObject selected;

    public ArrayList activePeople = new ArrayList();
    void Update()
    {
        Debug.Log(activePeople);
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Collider2D[] collidersUnderMouse = new Collider2D[4];
        int numCollidersUnderMouse = Physics2D.OverlapPoint(mousePos, new ContactFilter2D(), collidersUnderMouse);

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < numCollidersUnderMouse; ++i)
            {
                if (collidersUnderMouse[i].gameObject == selected && selected != null && selected.layer == LayerMask.NameToLayer("Ground"))
                {
                    ChangePersonTile();
                }
                else
                {
                    if (collidersUnderMouse[i].gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        if (activePeople.Contains(selected))
                        {
                            bool canPlace = true;
                            foreach (GameObject gameObject in activePeople)
                            {
                                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                                {
                                    if (gameObject.GetComponent<PersonTiling>().tile == collidersUnderMouse[i].gameObject)
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                            }
                            if (canPlace)
                            {
                                selected.GetComponent<PersonTiling>().tile = collidersUnderMouse[i].gameObject;
                            }
                            
                        }
                        else
                        {
                            SelectTile(collidersUnderMouse, i);
                        }
                    }
                }

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Unselect();
        }
    }

    void SelectTile(Collider2D[] collidersUnderMouse, int index)
    {
        Debug.Log("Selected " + collidersUnderMouse[index].gameObject);
        if (selected != null)
        {
            selected.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
        selected = collidersUnderMouse[index].gameObject;
        selected.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    void ChangePersonTile()
    {
        foreach (GameObject gameObject in activePeople)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (gameObject.GetComponent<PersonTiling>().tile == selected)
                {
                    selected.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                    selected = gameObject;
                    selected.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                }
            }
        }
    }

    void Unselect()
    {
        selected.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        selected = null;
    }

    
}
