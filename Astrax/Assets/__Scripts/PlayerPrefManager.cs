using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefManager 
{
    // Start is called before the first frame update
    
    public static int SetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        return 0;
    }
    public static void ScoreUpdate(int i)
    {
        PlayerPrefs.SetInt("Score",i);
    }
    public static void SetHighScore(int i)
    {
        PlayerPrefs.SetInt("HighScore",i);
    }
    public static int GetScore()
    {
        if(PlayerPrefs.HasKey("Score"))
        {
            return PlayerPrefs.GetInt("Score");
        }
        return 0;
    }
    public static int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        return 0;
    }
    public static int GetAchievement(string achievement)
    {
        if(PlayerPrefs.HasKey(achievement))
        {
            return PlayerPrefs.GetInt(achievement);
        }
        return 0;
    }
    public static void SetAchievement(string achievement, int achievementScore)
    {
        PlayerPrefs.SetInt(achievement, achievementScore);
    }
    public static void SetTurret(int turret)
    {
        PlayerPrefs.SetInt("Turret",turret);
    }
    public static int GetTurret()
    {
        if(PlayerPrefs.HasKey("Turret"))
        {
            return PlayerPrefs.GetInt("Turret");
        }
        return 0;
    }
    public static void SetBody(int body)
    {
        PlayerPrefs.SetInt("Body", body);
    }
    public static int GetBody()
    {
        if (PlayerPrefs.HasKey("Body"))
        {
            return PlayerPrefs.GetInt("Body");
        }
        return 0;
    }
    public static void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("HighScore", 5000);
        PlayerPrefs.SetInt("FirstDust", 0);
        PlayerPrefs.SetInt("LuckyShot", 0);
        PlayerPrefs.SetInt("TriggerHappy", 0);
        PlayerPrefs.SetInt("RookiePilot", 0);
        PlayerPrefs.SetInt("EagleEye", 0);
        PlayerPrefs.SetInt("SkillfulDodger", 0);
        PlayerPrefs.SetInt("ShotsFired", 0);
        PlayerPrefs.SetInt("LuckyShotsCount", 0);
        PlayerPrefs.SetInt("Turret",0);
        PlayerPrefs.SetInt("Body", 0);
        AchievementsManager.achievements.shotsFired = 0;
        AchievementsManager.achievements.luckyShotsCount = 0;
    }
}
