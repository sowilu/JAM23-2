using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : UnitySingleton<Leaderboard>
{
    public TMP_Text texPrefab;
    public Transform verticalLayout;

    public void Populate(List<string> entries)
    {
        //print(string.Join(", ", entries));  
        //StartCoroutine(PopulateCoroutine(entries));
        foreach (var entry in entries)
        {
            var text = Instantiate(texPrefab, verticalLayout);
            text.text = entry;
        }
    }

    IEnumerator PopulateCoroutine(List<string> entries)
    {
        foreach (var entry in entries)
        {
            var text = Instantiate(texPrefab, verticalLayout);
            text.text = entry;

            yield return new WaitForSeconds(0.2f);
        }
    }
}