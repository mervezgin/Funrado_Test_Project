using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelUpgrader : MonoBehaviour
{
    Animator playerAnimator;
    Vector3 respawnPosition;
    public int level = 1;
    [SerializeField] HeadLevelShow headLevelShow;
    [SerializeField] GameObject playerPrefab;

    float restartGameDelay = 2f;
    float attackDelay = 1f;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        UpdateLevelText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrader"))
        {
            Destroy(other.gameObject);
            IncreaseLevel();
        }
        else if (other.gameObject.CompareTag("Barrel"))
        {
            gameObject.SetActive(false);
            headLevelShow.HideLevelText();
            respawnPosition = other.transform.position;
            Invoke("RespawnPlayer", 2f);
        }
    }

    void IncreaseLevel()
    {
        level++;
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        if (headLevelShow != null)
        {
            headLevelShow.SetLevel(level);
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
            playerAnimator.SetBool("isAttacking", true);
            enemyController.enemyGameOver = true;
            //Destroy(enemyController.gameObject);
            //Destroy(enemyController.enemyLevelText.gameObject);
            enemyController.enemyAnimator.SetBool("Death_b", true);
            enemyController.enemyAnimator.SetInteger("DeathType_int", 1);
            Invoke("StopAttackAnimation", attackDelay);
        }
        else
        {
            enemyController.enemyAnimator.SetBool("isEnemyAttacking", true);
            enemyController.enemyGameOver = false;
            Invoke("RestartGameWhenEnemyAttackStop", 2);
        }
    }

    void StopAttackAnimation()
    {
        playerAnimator.SetBool("isAttacking", false);

    }

    void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void RestartGameWhenEnemyAttackStop()
    {
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
        Invoke("RestartGame", restartGameDelay);
    }

    void RespawnPlayer()
    {
        if (playerPrefab != null)
        {
            respawnPosition.z -= 2.0f;
            transform.position = respawnPosition;
            gameObject.SetActive(true);
            headLevelShow.ShowLevelText();
        }
    }

}
