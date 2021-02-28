using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text time;
    public Text points;
    public Text coins;
    public int timeLeft;
    double timeShow;

    private DateTime start;
    private DateTime now;
    private bool timesUp;
    private int score;
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        start = DateTime.Now;
        timesUp = false;
        score = 0;
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timesUp) {
            now = DateTime.Now;
            timeShow = timeLeft - Math.Round((DateTime.Now - start).TotalSeconds);
            time.text = "Time:\n" + timeShow;

            if (timeShow <= 0)
            {
                timesUp = true;
                Debug.Log("You lose!");
            }

            if (GameObject.Find("Ethan").transform.position.x > 210)
            {
                win();
            }
        }
    }

    public void scorePoints(int change, int coinsAdded) {
        score += change;
        coinCount += coinsAdded;
        points.text = "Score\n" + score;
        coins.text = "Coins: " + coinCount;
    }

    public void win() {
        if (!timesUp) {
            timesUp = true;
            Debug.Log("You win!");
        }
    }
}
