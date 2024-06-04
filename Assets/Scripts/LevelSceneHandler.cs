using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class LevelSceneHandler : MonoBehaviour
{
    float levelLoadDelay = 2f   ;
    bool isTransitioning = false;
    bool collisionDisabled = false;

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisionDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "BeginHere":
                Debug.Log("READY TO PLAY");
                break;
            case "NextLevel":
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex); 
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartDyingSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    
}
