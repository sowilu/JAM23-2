using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LeaderboardTest : MonoBehaviour
{
    public string name = "Test";
    
    public int score = 100;

    [Button("Add")]
    void Add()
    {
        print($"{name}, {score}");
        Leaderboard.inst.Add(name, score);
    }
    
    [Button("Clear")]
    void Clear()
    {
        Leaderboard.inst.Clear();
    }
}
