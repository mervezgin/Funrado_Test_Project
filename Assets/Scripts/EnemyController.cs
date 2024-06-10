using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    BoxCollider enemyBoxC;

    Vector3 initialColliderCenter;
    Vector3 initialColliderSize;

    public int enemyLevel; //enemy levelini temsil ediyor.
    public Text enemyLevelText; // enemy levelinin yazılı olduğu UI Text objesi.

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBoxC = GetComponent<BoxCollider>();

        enemyLevel = Random.Range(1, 5); //enemy leveline random bir değer atar.

        initialColliderCenter = enemyBoxC.center;
        initialColliderSize = enemyBoxC.size;

        UpdateLevelText(); //enemy leveli için texti yazdırır.
        Invoke("EnemyCircle", 1f);
    }

    void LateUpdate()
    {
        if (enemyBoxC != null)
        {
            enemyBoxC.center = initialColliderCenter;
            enemyBoxC.size = initialColliderSize;
        }
    }

    void UpdateLevelText()
    {
        if (enemyLevelText != null)
        {
            enemyLevelText.text = "LVL. " + enemyLevel;
        }
    }

    void EnemyCircle()
    {
        enemyAnimator.SetBool("isCircle", true);
    }

    void EnemyPatrol()
    {
        //enemy belirli bir range içinde yürüyebilir 
        //level2 da yapsın bunu 
    }
}
