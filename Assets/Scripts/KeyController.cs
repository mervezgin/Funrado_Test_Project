using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool hasRedKey = false; //Karakterin RedKey'e sahip olup olmadığını belirten değişken
    public bool hasBlueKey = false; //Karakterin BlueKey'e sahip olup olmadığını belirten değişken

    void OnTriggerEnter(Collider other) //RedKey ve BlueKey BoxCollider component'ında isTrigger seçili olmalı
    {
        if (other.gameObject.CompareTag("BlueKey")) //BlueKey tagi olan anahtarla triggerlandığında
        {
            hasBlueKey = true;
            Destroy(other.gameObject); //BlueKey'i yok eder
            Debug.Log("you can open blue door bro");
        }
        else if (other.gameObject.CompareTag("RedKey")) //RedKey tagi olan anahtarla triggerlandığında
        {
            hasRedKey = true;
            Destroy(other.gameObject); //RedKey'i yok eder
            Debug.Log("you can open red door bro");
        }
    }
}
