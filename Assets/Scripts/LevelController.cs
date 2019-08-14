using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    private Basket[] basketArray;

    public GameObject defeatInterface;
    public GameObject winInterface;

    public float playTime;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        basketArray = GameObject.FindObjectsOfType<Basket>();
        MyClass.currentGameState = GameState.Playing;


        playTime = 0;
    }


    void Update()
    {
        if (MyClass.currentGameState==GameState.Playing)
        {
            playTime += Time.deltaTime;
        }
    }


    public void GameStateRefresh()
    {
        if (MyClass.currentGameState == GameState.Playing)
        {
            if (ColorErrorJudge())
            {
                MyClass.currentGameState = GameState.ColorError;
                Debug.Log("ColorError");
                defeatInterface.SetActive(true);
            }
            else if (NumErrorJudge())
            {
                MyClass.currentGameState = GameState.NumError;
                Debug.Log("Numerror");
                defeatInterface.SetActive(true);
            }
            else if (WinJudge())
            {
                MyClass.currentGameState = GameState.Win;
                Debug.Log("YouWin");
                winInterface.SetActive(true);
            }
        }

    }


    private bool ColorErrorJudge()
    {

        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState == -1)
            {
                return true;
            }
        }
        return false;
    }


    private bool NumErrorJudge()
    {

        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState == -2)
            {
                return true;
            }
        }
        return false;
    }


    private bool WinJudge()
    {

        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState != 1)
            {
                return false;
            }
        }
        return true;
    }
}
