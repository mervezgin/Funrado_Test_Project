using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPass : MonoBehaviour   
{
    KeyController keyController;
    DoorOscillation doorOscillation;
    BoxCollider doorCollider;

    public bool isRedDoor;
    public bool isBlueDoor;

    float doorOpenDuration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        keyController = GameObject.FindWithTag("Player").GetComponent<KeyController>();
        doorOscillation = GetComponent<DoorOscillation>();
        doorCollider = GetComponent<BoxCollider>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isBlueDoor && keyController.hasBlueKey)
            {
                Debug.Log("Blue key detected, opening blue door.");
                OpenDoor();
                
            }
            else if (isRedDoor && keyController.hasRedKey)
            {
                Debug.Log("Red key detected, opening red door.");
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        if (doorOscillation != null)
        {
            doorOscillation.isOscillating = true;
            Debug.Log("kapı açıldı, osilasyon zamanı");
        }
        doorCollider.enabled = false;
        StartCoroutine(CloseDoorAfterDelay());
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(doorOpenDuration);
        Debug.Log("KAPI KAPANSIN");

        CloseDoor();
    }

    void CloseDoor()
    {
        if (doorOscillation != null)
        {
            doorOscillation.isOscillating = false;

            Debug.Log(doorOscillation.isOscillating);
        }
        doorCollider.enabled = true;
    }
}
