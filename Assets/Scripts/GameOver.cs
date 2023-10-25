using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int mainMenu;

    public void GameOverQuit()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
