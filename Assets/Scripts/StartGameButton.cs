using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScene;


    // starting of the game
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
