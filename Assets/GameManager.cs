using UnityEngine;
using UnityEngine.Events;

public class GameManager : UnitySingleton<GameManager>
{
    public static int score;
    public static int highScore;

    public static UnityEvent onGameStart = new();
    public static UnityEvent onGameEnd = new();

    void Save()
    {
        
    }

    void Load()
    {
        
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
        Health.onAnyDamage.AddListener((dmg) =>
        {
            score += dmg;
            if (score > highScore)
            {
                highScore = score;
            }
        });
    }
}
