using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelUpgrader : MonoBehaviour
{
    Animator animator; // Karakterin animasyonlarını kontrol etmek için 
    public int level = 1; // Karakterin başlangıç leveli = 1.
    [SerializeField] Text levelText; // Karakterin levelinin yazacağı UI Text objesi.

    float restartGameDelay = 2f;
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
            //enemy ölme animasyonu
        }
        else // Karakterin leveli enemynin levelinden düşük ise 
        {
            //playerin ölme animasyonu
            Invoke("RestartGame", restartGameDelay); //oyun yeni baştan başlar 
        }
    }
    void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
