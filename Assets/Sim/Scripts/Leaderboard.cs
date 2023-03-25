using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard inst;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(this);
    }

    public List<string> Add(string name, int score)
    {
        //send http get request to http://dreamlo.com/lb/[LBPRIVATE]/add-pipe/Carmine/100
        // Construct the URL for the HTTP request
        string url = $"http://dreamlo.com/lb/Rp0iHeFORkKgqd7iGbDuXQMHPAE7QFR0qSQCfCZsEmsQ/add-pipe/{name}/{score}";

        // Send the HTTP request
        var www = new WWW(url);

        while (!www.isDone) { }
        
        var board = new List<string>();
        
        //print(www.text);;
        
        foreach (var line in www.text.Split(Environment.NewLine))
        {
            //print(string.Join(',', www.text.Split(Environment.NewLine).ToArray()));
            if (line.Contains('|'))
            {
                
                var scores = line.Split('|');
                board.Add($"{scores[0]}-{scores[1]}");
            }
        }
        
        //print(string.Join("\n", board.ToArray()));
        return board;
    }
    
    

    public void Clear()
    {
        string url = $"http://dreamlo.com/lb/Rp0iHeFORkKgqd7iGbDuXQMHPAE7QFR0qSQCfCZsEmsQ/clear";

        // Send the HTTP request
        var www = new WWW(url);
    }
}
