using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneHandler : MonoBehaviour
{
    float levelLoadDelay = 2f; // Leveller arası geçiş süresi
    bool isTransitioning = false; // Level geçişinin olup olmadığını kontrol eder 
    bool collisionDisabled = false; // Çarpışma olup olmadığını kontrol eder

    void OnCollisionEnter(Collision collision) // bir nesne başka bir nesneye çarptığında çalışan metot.
    {
        if (isTransitioning || collisionDisabled) { return; } // Eğer geçiş devam ediyorsa ve çarpışmalar devre dışıysa OnCollisionEnter metodu sonlanır.

        switch (collision.gameObject.tag) //çarpışan nesnelerine tagine göre izlenecek metotlar
        {
            case "BeginHere": //Tag BeginHere ise konsola Ready to play yazar.
                Debug.Log("READY TO PLAY");
                break;
            case "NextLevel": //Tag NextLevel ise konsola Thank you next yazar. StartSuccessSequence() metodunu çalıştırır.
                StartSuccessSequence();
                Debug.Log("THANK YOU NEXT");
                break;
            default:
                //StartDyingSequence();
                break;
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //şu anda yüklü olan aktif sahneyi ve sahnenin yapı indeksi alıp döndürür.
        int nextSceneIndex = currentSceneIndex + 1; //Sıradaki sahneyi veren değişken
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // Bu, yapı ayarlarında bulunan toplam sahne sayısını döndürür. Eğer nextSceneIndex mevcut sahne sayısına eşitse, bu, geçerli sahnenin son sahne olduğunu gösterir.
        {
            nextSceneIndex = 0; //Sahne 0. sahneden başlar.
        }
        SceneManager.LoadScene(nextSceneIndex); // sıradaki sahneyi yükler.
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false; //PlayerController devre dışı bırakılır. 
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartDyingSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }


}
