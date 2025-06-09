using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PersonTiling : MonoBehaviour
{

    public GameObject person;
    public GameObject tile;


    void Start()
    {
        Camera.main.GetComponent<TileClick>().activePeople.Add(person);
    }
    void Update()
    {
        person.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);
    }
}
