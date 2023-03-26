using System;
using UnityEngine;
using UnityEngine.UI;


public class PieBar : MonoBehaviour
{
    [SerializeField] Image image;
    private bool hasFilled;
    public AudioClip fillSound;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = Mathf.Clamp01(image.fillAmount);
        
        if(image.fillAmount >= 1)
        {
            if(!hasFilled)
            {
                hasFilled = true;
                Pop();
            }
        }
        else
        {
            hasFilled = false;
        }
    }
    
    private void Pop()
    {
        Audio.Play(fillSound);
        //transform.localScale = Vector3.one * 1.2f;
    }
}
