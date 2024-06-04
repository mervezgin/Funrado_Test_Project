using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOscillation : MonoBehaviour
{
    public float amplitude = 0.3f;
    public float frequency = 0.3f;
    public bool isOscillating = false;


    float initialRotationZ;

    void Start()
    {

        initialRotationZ = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (isOscillating)
        {
            Debug.Log("DoorOscillation kodu içindeyim");
            float rotationZ = initialRotationZ + amplitude * Mathf.Sin(Time.time * frequency * 2 * Mathf.PI);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationZ);
        }
        else if (isOscillating == false)
        {
            Debug.Log("kapı kapandı");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotationZ);
        }
    }
}
