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
                OpenDoor();

            }
            else if (isRedDoor && keyController.hasRedKey)
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        if (doorOscillation != null)
        {
            doorOscillation.isOscillating = true;
        }
        doorCollider.enabled = false;
        StartCoroutine(CloseDoorAfterDelay());
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(doorOpenDuration);
        CloseDoor();
    }

    void CloseDoor()
    {
        if (doorOscillation != null)
        {
            doorOscillation.isOscillating = false;
        }
        doorCollider.enabled = false;
        //doorCollider.enabled = true ;//kapının boxcollider bileşeni etkin hale gelir ve karakterin geçmesine engel olur.
    }
}
