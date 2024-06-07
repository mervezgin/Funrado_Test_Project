using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelUpgrader : MonoBehaviour
{
    Animator animator;
    public int level = 1;
    [SerializeField] Text levelText;

    void Start()
    {
        animator = GetComponent<Animator>();
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

    void OnCollisionEnter(Collision other)
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();

        if (enemy != null)
        {
            PlayerAttack(enemy);
        }
    }
    void PlayerAttack(EnemyController enemyController)
    {
        if (level > enemyController.enemyLevel)
        {
            Destroy(enemyController.gameObject);
            Destroy(enemyController.enemyLevelText.gameObject);

            animator.SetBool("isAttacking", true);
            //player attack
            Debug.Log("Player attack now!!");
        }
        else
        {
            RestartGame();
            Debug.Log("Player is dead!");
        }
    }
    void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
