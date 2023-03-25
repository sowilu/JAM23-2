using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public static ItemUI inst;

    public ItemPopup popup;
    
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void DisplayItem(Spell spell)
    {
        popup.text.text = spell.description;
        
        //set popups position above item
        popup.transform.position = Camera.main.WorldToScreenPoint(spell.transform.position + Vector3.up);
        
        popup.gameObject.SetActive(true);
    }
    
    public void TurnOffPopup()
    {
        popup.gameObject.SetActive(false);
    }
}
