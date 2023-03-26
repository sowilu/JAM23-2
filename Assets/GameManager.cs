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

    [Header("Canvases")] 
    public GameObject titleScreenCanvas;
    public GameObject gameplayCanvas;

    public GameObject slowMusic;
    public GameObject fastMusic;
    
    
    private void Awake()
    {
        Load();
        
        InvokeRepeating(nameof(Save), saveInterval, saveInterval);
        
        onGameStart.AddListener(() =>
        {
            titleScreenCanvas.SetActive(false);
            gameplayCanvas.SetActive(true);
            GameplayUI.Instance.highScoreText.text = highScore.ToString();
            CameraFollow.Instance.zoom = 0;
            
            slowMusic.SetActive(false);
            fastMusic.SetActive(true);
        });
        
        onGameEnd.AddListener(() =>
        {
            gameplayCanvas.SetActive(false);
            
            slowMusic.SetActive(true);
            fastMusic.SetActive(false);
        });
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
            
            
        }); 
        
        
        Mutator.inst.onMutate.AddListener(MutateZoomRoutine);
    }
    
    public AudioClip slowdownSound;
    public int upgradeNumber = 0;
    async void MutateZoomRoutine(string str)
    {
        CameraFollow.Instance.zoom = 1;
        Audio.Play( slowdownSound);
        await new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 0.1f;
        await new WaitForSecondsRealtime(3);
        CameraFollow.Instance.zoom = 0;
        Time.timeScale = 1;
    }

    public void ShowLeaderboard()
    {
        if(GameplayUI.Instance.leaderboardUI.gameObject.activeSelf) return;
        
        var scores = Leaderboard.inst.Add("Hill Billy", score);
        GameplayUI.Instance.leaderboardUI.gameObject.SetActive(true);
        GameplayUI.Instance.leaderboardUI.Populate(scores);
    }
    
    public static void Pause(){
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        Time.timeScale = 1;
    }
}
