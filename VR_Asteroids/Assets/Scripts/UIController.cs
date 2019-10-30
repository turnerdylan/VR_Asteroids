using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    LevelLoader ll;
    ScreenShake ss;

    public TextMesh lives;
    public int numOfLives = 3;

    public TextMesh timer;
    float currentTime = 0;

    public Gun gun;
    public TextMesh ammo;
    int currentAmmo;

    public TextMesh score;
    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        ss = FindObjectOfType<ScreenShake>();
        ll = FindObjectOfType<LevelLoader>();
        lives.text = "Lives: " + numOfLives;
        timer.text = "Timer: " + currentTime;
        currentAmmo = gun.bulletCount;
        ammo.text = "Ammo: " + currentAmmo;

        currentScore = 0;
        score.text = "Score: " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        int seconds = (int)(currentTime % 60);
        timer.text = "Timer: " + seconds;
        currentAmmo = gun.bulletCount;
        ammo.text = "Ammo: " + currentAmmo;
        score.text = "Score: " + currentScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        ss.TriggerShake();
        numOfLives--;
        if(numOfLives >= 1)
        {
            lives.text = "Lives: " + numOfLives;
        }
        else
        {
            lives.text = "Game over!";
            lives.color = Color.red;
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        ll.LoadYouLose();
    }
}
