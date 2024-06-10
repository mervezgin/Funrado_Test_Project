using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    public bool hasRedKey = false;
    public bool hasBlueKey = false;

    public Image redKeyImage;
    public Image blueKeyImage;

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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueKey"))
        {
            if (blueKeyImage != null)
            {
                blueKeyImage.gameObject.SetActive(true);
                hasBlueKey = true;
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("RedKey"))
        {
            if (redKeyImage != null)
            {
                redKeyImage.gameObject.SetActive(true);
                hasRedKey = true;
                Destroy(other.gameObject);
            }
        }
    }
}
