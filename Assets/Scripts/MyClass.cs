using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Load,
    Playing,
    Win,
    NumError,
    ColorError
}


public class MyClass
{
    public static GameState currentGameState = GameState.Load;

    public static float[,] levelThresholdTime = { { 5, 10 }, { 8, 15 }, { 10, 20 } };

    public static int currentLevelIndex = 2;

    public static int totalCoinNum = 0;



    /// <summary>
    /// The color mix table.
    /// 0 red, 1 green, 2 blue, 3 yellow, 4 orange, 5 purple, 6 grey
    /// </summary>
    public static int[,] colorMixTable ={

        {0,5,6,4,6,6,6},
        {5,1,6,6,6,6,6},
        {6,6,2,6,6,6,6},
        {4,6,6,3,6,6,6},
        {6,6,6,6,4,6,6},
        {6,6,6,6,6,5,6},
        {6,6,6,6,6,6,6}


    };

}
