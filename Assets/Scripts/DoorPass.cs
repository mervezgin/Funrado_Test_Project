using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPass : MonoBehaviour
{
    KeyController keyController; // KeyController scriptini alır 
    DoorOscillation doorOscillation; //DoorOscillation scriptini alır 
    BoxCollider doorCollider; //BoxCollider bileşeni alır

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
            if (isBlueDoor && keyController.hasBlueKey) // Kapı mavi ve anahtar mavi ise OpenDoor() metodunu çağırır.
            {
                OpenDoor();

            }
            else if (isRedDoor && keyController.hasRedKey) // Kapı kırmızı ve anahtar kırmızı ise OpenDoor() metodunu çağırır.
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
        doorCollider.enabled = false; //kapının boxcollider bileşeni kapatıldığı için karakter kapıdan geçebilir.
        StartCoroutine(CloseDoorAfterDelay()); //belirli bir süre sonra kapıyı kapatmak için StartCoroutine
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(doorOpenDuration); // belirtilen süre kadar bekler.
        CloseDoor();
    }

    void CloseDoor()
    {
        if (doorOscillation != null)
        {
            doorOscillation.isOscillating = false;
        }
        doorCollider.enabled = true; //kapının boxcollider bileşeni etkin hale gelir ve karakterin geçmesine engel olur.
    }
}
