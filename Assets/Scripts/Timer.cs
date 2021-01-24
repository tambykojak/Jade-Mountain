using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text clockText;
    public Stopwatch stopwatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        StartCounting();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = stopwatch.Elapsed;
        string message = string.Format("{0:D2}:{1:D2}", ts.Seconds, ts.Milliseconds);
        UnityEngine.Debug.Log(message);
        clockText.text = message;
    }

    void StartCounting()
    {
        stopwatch.Start();
    }

    void ResetWatch()
    {
        stopwatch.Reset();
        clockText.text = "00:00";
    }

}
