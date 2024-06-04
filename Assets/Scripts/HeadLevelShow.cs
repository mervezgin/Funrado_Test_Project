using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadLevelShow : MonoBehaviour
{
    [SerializeField] Transform characterTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] Text levelText;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterTransform.position + offset);
        levelText.transform.position = screenPosition;
    }

    public void SetLevel(int level)
    {
        levelText.text = "Level: " + level;
    }
}
