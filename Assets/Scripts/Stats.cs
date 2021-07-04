using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Speed;
    public float Radius;
    public float WaitTime;
    public float Luck;
    public Status status = Status.decide;
    public GameObject explousive;

    private void Start()
    {
        
    }

    public void SetWaitTime(float wt) {
        WaitTime = wt;
    }

    public void SetLuck(float l)
    {
        Luck = l;
    }

    public void SetSpeed(float s)
    {
        Speed = s;
    }

    public void SetRadius(float r)
    {
        Radius = r;
    }
    public enum Status
    {
        dead,
        decide,
        patrool,
        await
    }
}
