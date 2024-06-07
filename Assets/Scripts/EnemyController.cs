using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int enemyLevel; //enemy levelini temsil ediyor.
    public Text enemyLevelText; // enemy levelinin yazılı olduğu UI Text objesi.
    // Start is called before the first frame update
    void Start()
    {
        enemyLevel = Random.Range(1, 3); //enemy leveline random bir değer atar.
        UpdateLevelText(); //enemy leveli için texti yazdırır.
    }

    void UpdateLevelText()
    {
        if (enemyLevelText != null)
        {
            enemyLevelText.text = "LVL. " + enemyLevel;
        }
    }
}
