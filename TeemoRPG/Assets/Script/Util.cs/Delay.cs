using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay
{
    public float delay{get;set;}
    public float elapsedTime{get; private set;}
    float lastTime;

    public Delay(float _delay = 0)
    {
        Start(_delay);
    }
    public void Start(float _delay)
    {
        delay = _delay;
        elapsedTime = 0;
        lastTime = Time.time;
    }
    public void Update()
    {
        elapsedTime += (Time.time - lastTime);
        lastTime = Time.time;
    }

    public bool Check() //true면 딜레이끝
    {
        Update();
        if(elapsedTime >= delay)
            return true;
        return false;
    }
}