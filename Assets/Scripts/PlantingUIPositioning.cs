using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlantingUIPositioning : MonoBehaviour
{
    public Rigidbody2D body;
    // Update is called once per frame
    void Update()
    {
        body.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y - 5);
    }
}
