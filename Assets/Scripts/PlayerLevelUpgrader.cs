using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelUpgrader : MonoBehaviour
{
    Animator animator; // Karakterin animasyonlarını kontrol etmek için 
    Vector3 respawnPosition;
    public int level = 1; // Karakterin başlangıç leveli = 1.
    [SerializeField] Text levelText; // Karakterin levelinin yazacağı UI Text objesi.
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> barrels = new List<GameObject>();

    float restartGameDelay = 2f;
    float attackDelay = 1f;
    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateLevelText();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrader")) //Karakter Upgrader tagi olan nesneyle karşılaşınca
        {
            Destroy(other.gameObject); //Upgrader gameObjecti yok edilir.
            IncreaseLevel(); //Levelin arttırıldığı metot çağırılır.
        }
        else if (other.gameObject.CompareTag("Barrel"))
        {
            gameObject.SetActive(false);
            respawnPosition = other.transform.position;
            Invoke("RespawnPlayer", 2f);
        }
    }
    void IncreaseLevel()
    {
        level++; // level değişkeni bir kere arttırılır.
        UpdateLevelText(); // Bu metot çağırılır.
    }
    void UpdateLevelText()
    {
        if (levelText != null) // eğer inspectorda levelText bileşeni boş değilse
        {
            levelText.text = "LVL. " + level;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>(); // Karakterin çarpıştığı gameObjectin EnemyController bileşenine sahip olup olmadığı kontrol edilir. PlayerAttack metodu çağrılır.

        if (enemy != null)
        {
            PlayerAttack(enemy);
        }
    }
    void PlayerAttack(EnemyController enemyController)
    {
        if (level > enemyController.enemyLevel) // Karakterin leveli enemynin levelinden yüksek ise 
        {
            animator.SetBool("isAttacking", true); // Karakterin attack animasyonunu devreye geçir 
            Destroy(enemyController.gameObject); //enemy yi yok et 
            Destroy(enemyController.enemyLevelText.gameObject); // enemynin level göstergesini yok et.
            Invoke("StopAttackAnimation", attackDelay);
            //enemy ölme animasyonu
        }
        else // Karakterin leveli enemynin levelinden düşük ise 
        {
            //playerin ölme animasyonu
            //Enemy attack animasyonu 
            enemyController.enemyAnimator.SetBool("isEnemyAttacking", true);
            Invoke("StopEnemyAttack", attackDelay);
            Invoke("RestartGame", restartGameDelay); //oyun yeni baştan başlar 
        }
    }

    void StopAttackAnimation()
    {
        animator.SetBool("isAttacking", false);
    }

    void StopEnemyAttack(EnemyController enemyController)
    {
        enemyController.enemyAnimator.SetBool("isEnemyAttacking", false);
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
            transform.position = respawnPosition; // Player objesini başlangıç konumuna taşı
            gameObject.SetActive(true); // Player objesini yeniden etkinleştir
        }
    }
}
