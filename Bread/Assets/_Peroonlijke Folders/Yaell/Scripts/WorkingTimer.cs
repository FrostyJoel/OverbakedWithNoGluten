using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Timer", menuName = "Timer")]
public class WorkingTimer : ScriptableObject
{
    public float startTimer;
    public float endTimer;
    public float restartTimer;

    public virtual void RunningTimer()
    {
        if (startTimer > endTimer)
            startTimer -= Time.deltaTime;

        else if(startTimer <= endTimer)
        {
            startTimer = endTimer;
            Debug.Log("Stop");
        }
    }
}
