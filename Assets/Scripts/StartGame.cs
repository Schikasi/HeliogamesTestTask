using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject prefabCube;
    // Start is called before the first frame update
    void Start()
    {
        Stats stats = prefabCube.GetComponent<Stats>();
        stats.SetSpeed(0.0f);
        stats.SetWaitTime(0.0f);
        stats.SetLuck(0.0f);
        stats.SetRadius(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
