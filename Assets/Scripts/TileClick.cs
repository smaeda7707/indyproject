using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClick : MonoBehaviour
{
    void Update(){
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                print("clicked");
            }
        }
    }
}
