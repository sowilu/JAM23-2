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
        Mutator.inst.onMutate.AddListener(ShowMood);
    }

    void ShowMood(string mood)
    {
        textBox.text = mood;
        StartCoroutine(ShowMoodRoutine());
    }

    IEnumerator ShowMoodRoutine()
    {
        textBox.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);
        
        textBox.gameObject.SetActive(false);
    }

}
