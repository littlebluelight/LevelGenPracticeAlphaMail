using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameToModeScreen;
    public string playMainMenu;
    public string playInstructions;

    public void PlayGame(){

        Application.LoadLevel(playGameToModeScreen);

    }

    public void ToInstructions()
    {

        Application.LoadLevel(playInstructions);

    }

    public void BackToMain(){
        Application.LoadLevel(playMainMenu);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
