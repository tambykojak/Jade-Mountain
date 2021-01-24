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
        Debug.Log(stopwatch.Elapsed.ToString());
        clockText.text = stopwatch.Elapsed.ToString();
    }

    void StartCounting()
    {
        stopwatch.Start();
    }

    void ResetWatch()
    {
        stopwatch.Reset();
    }

}
