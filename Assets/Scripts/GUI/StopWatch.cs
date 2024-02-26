using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public Stopwatch stopwatch = new Stopwatch();
    public TextMeshProUGUI Watch;
    public bool IsCounting = false;
    public GameObject Clock;

    public void StartCounting(){
        Clock.SetActive(true);
        stopwatch.Start();
        IsCounting = true;
    }

    public async void StopCounting(){
        stopwatch.Stop();
        await Task.Delay(100);
        IsCounting = false;
    }

    void Update()
    {
        if(IsCounting) Watch.text = stopwatch.Elapsed.ToString("hh':'mm':'ss'.'ff");
    }
}
