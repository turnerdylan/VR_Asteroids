using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMesh lives;
    public int numOfLives = 3;

    public TextMesh timer;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        lives.text = "Lives: " + numOfLives;
        timer.text = "Timer: " + currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        int seconds = (int)(currentTime % 60);
        timer.text = "Timer: " + currentTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        numOfLives--;
        lives.text = "Lives: " + numOfLives;
    }
}
