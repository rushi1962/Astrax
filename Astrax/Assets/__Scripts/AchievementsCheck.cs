using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lockedButtons;
    public GameObject[] unlockedButtons;
    public GameObject[] tickMarks;
    public string[] achievements = { "FirstDust", "LuckyShot","TriggerHappy","RookiePilot","EagleEye","SkillfulDodger"};
    int turret, body;
    void Start()
    {
        achievements[0] = "FirstDust";
        for(int i=0;i<achievements.Length;i++)
        {
           // print(achievements[i]+"="+ PlayerPrefManager.GetAchievement(achievements[i]));
            if(PlayerPrefManager.GetAchievement(achievements[i]) == 1)
            {
                lockedButtons[i].SetActive(false);
                unlockedButtons[i].SetActive(true);
            }
            else
            {
                lockedButtons[i].SetActive(true);
                unlockedButtons[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(PlayerPrefManager.GetAchievement(achievements[1]));
        for (int i = 0; i < achievements.Length; i++)
        {
            if (PlayerPrefManager.GetAchievement(achievements[i]) == 1)
            {
                lockedButtons[i].SetActive(false);
                unlockedButtons[i].SetActive(true);
            }
            else
            {
                lockedButtons[i].SetActive(true);
                unlockedButtons[i].SetActive(false);
            }
        }
        turret = GameManager.gm.turret;
        body = GameManager.gm.body;
        for(int i=0;i<8;i++)
        {
            if(i<4)
            {
                if(i==turret)
                {
                    tickMarks[i].SetActive(true);
                }
                else
                {
                    tickMarks[i].SetActive(false);
                }
            }
            if(i>=4)
            {
                if (i-4 == body)
                {
                    tickMarks[i].SetActive(true);
                }
                else
                {
                    tickMarks[i].SetActive(false);
                }
            }
        }
    }
}
