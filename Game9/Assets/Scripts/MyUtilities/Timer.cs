using UnityEngine;
using System.Collections;
/// <summary>
/// Timer that counts up from 0 and is updated every single frame.
/// </summary>
public class Timer : MonoBehaviour {

    // TIMER counting UP
    private float timer = 0.0f;

    public float TimerValue
    {
        get { return (int)timer; }
        //We don't want to set timer from other scripts!
        //Therefore set is commented out
        //set { timer = value; } 
    }
    void  Update()
    {
        timer += Time.deltaTime;
    }
}
