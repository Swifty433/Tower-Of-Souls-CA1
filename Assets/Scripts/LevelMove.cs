using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // a scene management tool to switch between scenes

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;


    // if player collides with box
    private void OnTriggerEnter2D(Collider2D other)
    {
        //console statement
        print("Next Level");

        //the tag for player character
        if(other.tag == "Player")
        {
            //player moves to next level if in collision box
            print("Switching Level to " + sceneBuildIndex);
            //next level managed within unity editor
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
