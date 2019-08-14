using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatInterface : MonoBehaviour
{
    public Text defeatInfoText;


    void Start()
    {

    }


    void Update()
    {

    }


    private void OnEnable()
    {
        if (MyClass.currentGameState == GameState.ColorError)
        {
            defeatInfoText.text = "MISMATCH \n COLOR";
        }
        if (MyClass.currentGameState == GameState.NumError)
        {
            defeatInfoText.text = "TOO MANY \n MARBLES";
        }
    }


    public void TryAgainButtonClick()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
