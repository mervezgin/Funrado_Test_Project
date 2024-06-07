using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOscillation : MonoBehaviour
{
    public float amplitude = 0.3f; // Kapının ne kadar sallanacağını belirler.
    public float frequency = 0.3f; // Kapının ne kadar hızlı sallanacağını belirler.
    public bool isOscillating = false;

    float initialRotationZ; //Kapının başlangıçtaki z eks. rotasyonunu saklar.

    void Start()
    {
        initialRotationZ = transform.rotation.eulerAngles.z; //Kapının geri döneceği rotasyonu belirler.
    }

    void Update()
    {
        if (isOscillating)
        {
            float rotationZ = initialRotationZ + amplitude * Mathf.Sin(Time.time * frequency * 2 * Mathf.PI); // (Time.time * frequency * 2 * Mathf.PI) = zamanın belirli bir frekansta ilerlemesini sağlar. bu değer amplitude ile çarpılınca salınımın genliğini belirler.
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationZ);
        }
        else if (isOscillating == false)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotationZ); //burda bir şeyi yanlış yapıyorum. çünkü salınımın aslında initial rotationa dönmesi lazım ama dönmüyor düzelt
        }
    }
}
