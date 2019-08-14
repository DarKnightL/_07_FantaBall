using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinInterface : MonoBehaviour
{

    public Text PlayerTimeText;
    public Text GoalTimeText;
    public Text BestTimeText;

    public Text coinNumText;


    public Image firstStar;
    public Image secondStar;
    public Image thirdStar;

    private Sprite emptyStar;
    private Sprite filledStar;

    private int starLevel;


    void Start()
    {

    }


    void Update()
    {

    }


    private void DisplayTime(float targetTime, Text targetText)
    {

        TimeSpan tempTimeSpan = new TimeSpan(0, 0, (int)targetTime);
        targetText.text = tempTimeSpan.Minutes.ToString("00") + ":" + tempTimeSpan.Seconds.ToString("00");
    }



    private void OnEnable()
    {
        DisplayTime(LevelController.instance.playTime, PlayerTimeText);
        DisplayTime(MyClass.levelThresholdTime[MyClass.currentLevelIndex, 0], GoalTimeText);

        float tempBestTime = PlayerPrefs.GetFloat("bestTime" + MyClass.currentLevelIndex, float.MaxValue);

        if (LevelController.instance.playTime < tempBestTime)
        {
            tempBestTime = LevelController.instance.playTime;
            PlayerPrefs.SetFloat("bestTime" + MyClass.currentLevelIndex, tempBestTime);
        }
        DisplayTime(tempBestTime, BestTimeText);


        emptyStar = Resources.Load<Sprite>("Star/EmptyStar");
        filledStar = Resources.Load<Sprite>("Star/FilledStar");


        CalculateStarLevel();
        DisplayStarLevel();
        DisplayCoins();
    }



    public void PlayAgainButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    private void CalculateStarLevel()
    {
        if (LevelController.instance.playTime < MyClass.levelThresholdTime[MyClass.currentLevelIndex, 0])
        {
            starLevel = 3;
        }
        else if (LevelController.instance.playTime < MyClass.levelThresholdTime[MyClass.currentLevelIndex, 1])
        {
            starLevel = 2;
        }
        else
        {
            starLevel = 1;
        }
    }


    private void DisplayStarLevel(){

        if (starLevel==3)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = filledStar;
            thirdStar.sprite = filledStar;
        }
        if (starLevel==2)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = filledStar;
            thirdStar.sprite = emptyStar;
        }
        if (starLevel == 1)
        {
            firstStar.sprite = emptyStar;
            secondStar.sprite = emptyStar;
            thirdStar.sprite = emptyStar;
        }
    }


    private void DisplayCoins(){

        int tempCoin = 50 * starLevel;
        coinNumText.text = "+ " + tempCoin;

        MyClass.totalCoinNum = PlayerPrefs.GetInt("totalCoinNum", 0);
        MyClass.totalCoinNum += tempCoin;
        PlayerPrefs.SetInt("totalCoinNum", MyClass.totalCoinNum);
    }


}
