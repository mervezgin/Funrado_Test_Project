using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUpgrader : MonoBehaviour
{
    public int level = 1;
    [SerializeField] Text levelText;

    void Start()
    {
        UpdateLevelText();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrader"))
        {
            Debug.Log("YOU LUCKY");
            Destroy(other.gameObject);
            IncreaseLevel();
            Debug.Log(level);
        }
    }

    void IncreaseLevel()
    {
        level++;
        UpdateLevelText();
    }
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "LVL. " + level;
        }
    }
}
