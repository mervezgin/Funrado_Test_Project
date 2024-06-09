using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    public bool hasRedKey = false; //Karakterin RedKey'e sahip olup olmadığını belirten değişken
    public bool hasBlueKey = false; //Karakterin BlueKey'e sahip olup olmadığını belirten değişken

    [SerializeField] Image redKeyImage;
    [SerializeField] Image blueKeyImage;

    void Start()
    {
        if (redKeyImage != null)
        {
            redKeyImage.gameObject.SetActive(false);
        }
        if (blueKeyImage != null)
        {
            blueKeyImage.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other) //RedKey ve BlueKey BoxCollider component'ında isTrigger seçili olmalı
    {
        if (other.gameObject.CompareTag("BlueKey")) //BlueKey tagi olan anahtarla triggerlandığında
        {
            if (blueKeyImage != null)
            {
                blueKeyImage.gameObject.SetActive(true);
                hasBlueKey = true;
                Destroy(other.gameObject); //BlueKey'i yok eder
            }
        }
        else if (other.gameObject.CompareTag("RedKey")) //RedKey tagi olan anahtarla triggerlandığında
        {
            if (redKeyImage != null)
            {
                redKeyImage.gameObject.SetActive(true);
                hasRedKey = true;
                Destroy(other.gameObject); //RedKey'i yok eder
            }
        }
    }
}
