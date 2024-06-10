using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelUpgrader : MonoBehaviour
{
    Animator animator; // Karakterin animasyonlarını kontrol etmek için 
    Vector3 respawnPosition;
    public int level = 1;
    [SerializeField] HeadLevelShow headLevelShow;
    [SerializeField] GameObject playerPrefab;

    float restartGameDelay = 2f;
    float attackDelay = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            headLevelShow.HideLevelText(); // Seviye metnini gizle
            respawnPosition = other.transform.position;
            Invoke("RespawnPlayer", 2f);
        }
    }

    void IncreaseLevel()
    {
        level++; // level değişkeni bir kere arttırılır.
        Debug.Log("ARTMADI LEVEL");
        UpdateLevelText(); // Bu metot çağırılır.
    }

    public void UpdateLevelText()
    {
        if (headLevelShow != null) // HeadLevelShow betiği varsa
        {
            Debug.Log("buraya giriyor mu bu ");
            headLevelShow.SetLevel(level); // HeadLevelShow betiğine seviyeyi ayarla
            Debug.Log(level);
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
        if (level > enemyController.enemyLevel) // Karakterin leveli enemynin levelinden yüksek ise 
        {
            animator.SetBool("isAttacking", true);
            Destroy(enemyController.gameObject);
            Destroy(enemyController.enemyLevelText.gameObject);
            Invoke("StopAttackAnimation", attackDelay);

        }
        else // Karakterin leveli enemynin levelinden düşük ise 
        {
            //playerin ölme animasyonu
            enemyController.enemyAnimator.SetBool("isEnemyAttacking", true);
            Invoke("RestartGame", restartGameDelay);
        }
    }

    void StopAttackAnimation()
    {
        animator.SetBool("isAttacking", false);
    }

    void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
