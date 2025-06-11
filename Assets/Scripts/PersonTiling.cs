using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PersonTiling : MonoBehaviour
{

    public GameObject person;
    public GameObject tile;

    public bool active;

    void Start()
    {
        active = true;
    }
    void Update()
    {
        if (active && tile != null)
        {
            if (!Camera.main.GetComponent<TileClick>().activePeople.Contains(person))
            {
                Camera.main.GetComponent<TileClick>().activePeople.Add(person);
            }
        }
        person.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);
    }
}
