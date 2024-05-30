using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool hasRedKey = false;
    public bool hasBlueKey = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueKey"))
        {
            hasBlueKey = true;
            Destroy(other.gameObject);
            Debug.Log("you can open blue door bro");
            //open the blue door with oscillation
        }
        else if (other.gameObject.CompareTag("RedKey"))
        {
            hasRedKey = true;
            Destroy(other.gameObject);
            Debug.Log("you can open red door bro");
            //open the red door with oscillation
        }
    }
}
