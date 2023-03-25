using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetMoodUI : MonoBehaviour
{
    public float duration = 5f;
    public TextMeshProUGUI textBox;
    
    void Start()
    {
        if(Mutator.inst != null)
            Mutator.inst.onMutate.AddListener(ShowMood);
    }

    void ShowMood(string mood)
    {
        if (string.IsNullOrEmpty(mood))
            return;
        //TODO: check why item passes not null check but is still null here
        try
        {
            textBox.text = mood;
            StartCoroutine(ShowMoodRoutine());
        }
        catch (Exception)
        {
        }
    }

    IEnumerator ShowMoodRoutine()
    {
        textBox.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);
        
        textBox.gameObject.SetActive(false);
    }

}
