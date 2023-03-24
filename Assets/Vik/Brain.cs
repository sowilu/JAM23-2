using System;
using NaughtyAttributes;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public Transform target;
    public Action currentAction;
    public Action lastFrameAction;

    [MinMaxSlider(1,50)]public Vector2 sleepDuration;
    [MinMaxSlider(1,50)]public Vector2 idleDuration;
    [MinMaxSlider(1,50)]public Vector2 escapeDuration;
    
    [Range(0,1)]public float sleepiness = 0;
    [Range(0,1)]public float hunger = 0;
    [Range(0,1)]public float fear = 0;
    
    float sleepRate;
    float hungerRate;
    float fearRate;

    private bool stateJustChanged;

    private void Start()
    {
        currentAction = Idle;
    }

    private void Update()
    {
        stateJustChanged = currentAction != lastFrameAction;
        lastFrameAction = currentAction;
        
        currentAction?.Invoke();
        
        sleepiness += sleepRate * Time.deltaTime;
        hunger += hungerRate * Time.deltaTime;
        fear += fearRate * Time.deltaTime;
    }


    void Idle()
    {
        if (stateJustChanged)
        {
            sleepRate = 0.1f;
            hungerRate = 0.1f;
        }
        
        if( sleepiness > 0.5f)
        {
            currentAction = Sleep;
        }
        
        if(hunger > 0.5f)
        {
            currentAction = Eat;
        }
    }


    void Sleep()
    {
        if( stateJustChanged)
        {
            sleepRate = -0.3f;
            hungerRate = 0.1f;
        }
        
        if(sleepiness <= 0)
        {
            currentAction = Idle;
        }
    }

    void Eat()
    {
        if( stateJustChanged)
        {
            sleepRate = 0.1f;
            hungerRate = -0.3f;
            // find near food
        }
        
        // move to food
        
    }
    
}
