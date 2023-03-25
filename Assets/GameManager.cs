using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : UnitySingleton<GameManager>
{
    public static int score;
    public static int highScore;

    public static UnityEvent onGameStart = new();
    public static UnityEvent onGameEnd = new();

    public float saveInterval = 5f;
    private void Awake()
    {
        Load();
        
        InvokeRepeating(nameof(Save), saveInterval, saveInterval);
    }
    
    

    void Save()
    {
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
    }

    void Load()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
        else
        {
            Load();
        }
    }


    private void Start()
    {
        Player.inst.health.onDie.AddListener(() =>
        {
            ShowLeaderboard();
            onGameEnd.Invoke();
        });
        
        Health.onAnyDamage.AddListener((dmg) =>
        {
            score += dmg;
            if (score > highScore)
            {
                highScore = score;
            }
            
            
            GameplayUI.Instance.scoreText.text = score.ToString();
        }); 
    }

    public void ShowLeaderboard()
    {
        if(GameplayUI.Instance.leaderboardUI.gameObject.activeSelf) return;
        
        var scores = Leaderboard.inst.Add("Hill Billy", score);
        GameplayUI.Instance.leaderboardUI.gameObject.SetActive(true);
        GameplayUI.Instance.leaderboardUI.Populate(scores);
    }
}
