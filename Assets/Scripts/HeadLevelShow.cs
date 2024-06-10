using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadLevelShow : MonoBehaviour
{
    [SerializeField] Transform characterTransform;
    public Vector3 offset;
    public Text levelText;

    void Update()
    {
        if (levelText != null && characterTransform != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterTransform.position + offset);
            levelText.transform.position = screenPosition;
        }
    }

    public void SetLevel(int level)
    {
        if (levelText != null)
        {
            levelText.text = "LVL. " + level;
        }
    }

    public void HideLevelText()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(false);
        }
    }

    public void ShowLevelText()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(true);
        }
    }
}
