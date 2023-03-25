using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public TMP_Text texPrefab;
    public Transform verticalLayout;

    public void Populate(List<string> entries)
    {
        foreach (var entry in entries)
        {
            var text = Instantiate(texPrefab, verticalLayout);
            text.text = entry;
        }
    }
}