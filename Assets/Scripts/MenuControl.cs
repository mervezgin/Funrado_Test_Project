using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] Sprite[] musicIcons;
    [SerializeField] Button musicButton;
    void Start()
    {
        if (MusicOptions.MusicOpenIsThereRecord() == true) { MusicOptions.MusicOpenSend(1); }
        MusicSettingsCheck();
    }
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Music()
    {
        if (musicIcons != null && MusicControl.instance != null && musicButton != null)
        {
            if (MusicOptions.MusicOpenRead() == 1)
            {
                MusicOptions.MusicOpenSend(0);
                MusicControl.instance.PlayMusic(false);
                musicButton.image.sprite = musicIcons[0];
            }
            else
            {
                MusicOptions.MusicOpenSend(1);
                MusicControl.instance.PlayMusic(true);
                musicButton.image.sprite = musicIcons[1];
            }
        }
    }

    void MusicSettingsCheck()
    {
        if (musicIcons != null && MusicControl.instance != null && musicButton != null)
        {
            if (MusicOptions.MusicOpenRead() == 1)
            {
                musicButton.image.sprite = musicIcons[1];
                MusicControl.instance.PlayMusic(true);
            }
            else
            {
                musicButton.image.sprite = musicIcons[0];
                MusicControl.instance.PlayMusic(false);
            }
        }
    }
}