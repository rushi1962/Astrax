using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager achievements;
    public int firstDust, luckyShot, triggerHappy, rookiePilot, eagleEye, skillfulDodger;
    public int shotsFired, luckyShotsCount;
    public List<string> achievementsNames;
    public Text achievement,description;
    public Animator popupAnimation;
    private string[] descriptions = { "Shot your first asteroid", "Bullet wrapped screen & hit asteroid", "1000 Shots fired", "Score above 10000", "100 lucky shots", "Reached level 5","You set a new high score!" };
    private float _currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        if(achievements==null)
        {
            achievements = gameObject.GetComponent<AchievementsManager>();
        }
    }
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("FirstDust"))
        {
            PlayerPrefManager.SetAchievement("FirstDust", 0);
        }
        if (!PlayerPrefs.HasKey("LuckyShot"))
        {
            PlayerPrefManager.SetAchievement("LuckyShot", 0);
        }
        if (!PlayerPrefs.HasKey("TriggerHappy"))
        {
            PlayerPrefManager.SetAchievement("TriggerHappy", 0);
        }
        if (!PlayerPrefs.HasKey("RookiePilot"))
        {
            PlayerPrefManager.SetAchievement("RookiePilot", 0);
        }
        if (!PlayerPrefs.HasKey("EagleEye"))
        {
            PlayerPrefManager.SetAchievement("EagleEye", 0);
        }
        if (!PlayerPrefs.HasKey("SkillfulDodger"))
        {
            PlayerPrefManager.SetAchievement("SkillfulDodger", 0);
        }
        if (!PlayerPrefs.HasKey("ShotsFired"))
        {
            PlayerPrefManager.SetAchievement("ShotsFired", 0);
        }
        if (!PlayerPrefs.HasKey("LuckyShotsCount"))
        {
            PlayerPrefManager.SetAchievement("LuckyShotsCount", 0);
        }            
       
        achievementsNames = new List<string>();
        _currentTime = -10f;
        firstDust = PlayerPrefManager.GetAchievement("FirstDust");
        luckyShot = PlayerPrefManager.GetAchievement("LuckyShot");
        triggerHappy = PlayerPrefManager.GetAchievement("TriggerHappy");
        rookiePilot = PlayerPrefManager.GetAchievement("RookiePilot");
        eagleEye = PlayerPrefManager.GetAchievement("EagleEye");
        skillfulDodger = PlayerPrefManager.GetAchievement("SkillfulDodger");
        shotsFired = PlayerPrefManager.GetAchievement("ShotsFired");
        luckyShotsCount = PlayerPrefManager.GetAchievement("LuckyShotsCount");
        if (GameManager.gm.level == 5 && skillfulDodger == 0)
        {
            skillfulDodger = 1;
            PlayerPrefManager.SetAchievement("SkillfulDodger", rookiePilot);
            achievementsNames.Insert(0,"SkillfulDodger");
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefManager.SetAchievement("ShotsFired", shotsFired);
        PlayerPrefManager.SetAchievement("LuckyShotsCount",luckyShotsCount);
        if (GameManager.gm.score>0&&firstDust==0)
        {
            firstDust = 1;
            PlayerPrefManager.SetAchievement("FirstDust", firstDust);
            achievementsNames.Insert(0,"FirstDust");
        }
        if(GameManager.gm.score>10000&&rookiePilot==0)
        {
            rookiePilot = 1;
            PlayerPrefManager.SetAchievement("RookiePilot", rookiePilot);
            achievementsNames.Insert(0, "RookiePilot");
        }
       
        if(shotsFired>1000&&triggerHappy==0)
        {
            triggerHappy = 1;
            PlayerPrefManager.SetAchievement("TriggerHappy", triggerHappy);
            achievementsNames.Insert(0,"TriggerHappy");
        }
        if(luckyShotsCount>0&&luckyShot==0)
        {
            luckyShot = 1;
            PlayerPrefManager.SetAchievement("LuckyShot", luckyShot);
            achievementsNames.Insert(0,"LuckyShot");
        }
        if(luckyShotsCount>100&&eagleEye==0)
        {
            eagleEye = 1;
            PlayerPrefManager.SetAchievement("EagleEye", eagleEye);
            achievementsNames.Insert(0,"EagleEye");
        }
        if(GameManager.gm.score>PlayerPrefManager.GetHighScore())
        {
            achievementsNames.Insert(0, "New HighScore");
            PlayerPrefManager.SetHighScore(GameManager.gm.score);
        }
        
    }
    void LateUpdate()
    {
        if (achievementsNames.Count > 0 && _currentTime == -10f)
        {
            _currentTime = 2f;
           
        }
        if (_currentTime != -10f && _currentTime<0f&& achievementsNames.Count > 0)
        {
            
            achievement.text = achievementsNames[achievementsNames.Count - 1];
            if(achievementsNames[achievementsNames.Count - 1]=="FirstDust")
            {
                description.text = descriptions[0];
            }
            if (achievementsNames[achievementsNames.Count - 1] == "LuckyShot")
            {
                description.text = descriptions[1];
            }
            if (achievementsNames[achievementsNames.Count - 1] == "TriggerHappy")
            {
                description.text = descriptions[2];
            }
            if (achievementsNames[achievementsNames.Count - 1] == "RookiePilot")
            {
                description.text = descriptions[3];
            }
            if (achievementsNames[achievementsNames.Count - 1] == "EagleEye")
            {
                description.text = descriptions[4];
            }
            if (achievementsNames[achievementsNames.Count - 1] == "SkillfulDodger")
            {
                description.text = descriptions[5];
            }
            if(achievementsNames[achievementsNames.Count - 1] == "New HighScore")
            {
                description.text = descriptions[6];
            }
            popupAnimation.SetTrigger("Popup");
            achievementsNames.RemoveAt(achievementsNames.Count - 1);
            _currentTime = -10f;
        }
        else if(_currentTime != -10f && _currentTime > 0f && achievementsNames.Count > 0)
        {
            _currentTime -= Time.deltaTime;
        }

    }
   
}
