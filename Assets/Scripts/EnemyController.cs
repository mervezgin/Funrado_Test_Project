using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int enemyLevel;
    public Text enemyLevelText;
    // Start is called before the first frame update
    void Start()
    {
        enemyLevel = Random.Range(1, 3);
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        if (enemyLevelText != null)
        {
            enemyLevelText.text = "LVL. " + enemyLevel;
        }
    }
}
