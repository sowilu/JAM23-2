using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public Health playerHealth;



    void Update()
    {
        //smoothly scale bar according to health
        bar.localScale = Vector3.Lerp(bar.localScale, new Vector3(playerHealth.HP / 100f, 1, 1), Time.deltaTime * 10);
        
    }
}
