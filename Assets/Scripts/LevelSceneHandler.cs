using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSceneHandler : MonoBehaviour
{
    PlayerLevelUpgrader playerLevelUpgrader;
    float levelLoadDelay = 2f;
    bool isTransitioning = false;
    bool collisionDisabled = false;

    [SerializeField] Text gameLevelText;

    void Update()
    {
        UpdateGameLevelText();
    }
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
                break;
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void UpdateGameLevelText()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameLevelText.text = "LEVEL " + (currentSceneIndex + 1);
    }

}
