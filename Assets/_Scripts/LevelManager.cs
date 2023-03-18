using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text timer;
    public Text gameText;
    public static bool isGameOver;
    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;
    public string nextLevel;
    public static float currentTime;
    public static int score = 0;
    public Text scoreText;
    private int currentScore;

    public Text buttonPrompt;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        currentTime = 0.0f;
        SetTimerText();
        scoreText.text = score.ToString();
        //currentScore = PickupBehavior.pickupCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            scoreText.text = score.ToString();
            currentTime += Time.deltaTime; 
            SetTimerText();
            /*
             This is where we set condition for next level
            if ()
            {
                LevelBeat();
            }*/
        }
    }

    private void SetTimerText()
    {
        timer.text = currentTime.ToString("f2");
    }

    public void LevelLost()
    {
        isGameOver = true;
        gameText.text = "Game Over!";
        gameText.gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);
        Invoke("LoadCurrentLevel", 2);
        // score = 0;
    }

    public void LevelBeat()
    {
        isGameOver = true;
        gameText.text = "You win!";
        gameText.gameObject.SetActive(true);
        //AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);
        if (!string.IsNullOrEmpty(nextLevel))
        { 
            Invoke("LoadNextLevel", 2);
            score = 0;
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetButtonPromptActive(bool state)
    {
        this.buttonPrompt.enabled = state;
    }
}
