using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text time;
    public int timeLeft;

    private DateTime start;
    private DateTime now;

    // Start is called before the first frame update
    void Start()
    {
        start = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        now = DateTime.Now;
        time.text = "Time:\n" + (timeLeft - Math.Round((DateTime.Now - start).TotalSeconds));
    }
}
