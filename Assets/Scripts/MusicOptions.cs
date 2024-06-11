using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MusicOptions
{
    public static string musicOpen = "musicOpen";

    public static void MusicOpenSend(int musicOpen) { PlayerPrefs.SetInt(MusicOptions.musicOpen, musicOpen); }
    public static int MusicOpenRead() { return PlayerPrefs.GetInt(MusicOptions.musicOpen); }

    public static bool MusicOpenIsThereRecord()
    {
        if (PlayerPrefs.HasKey(MusicOptions.musicOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
