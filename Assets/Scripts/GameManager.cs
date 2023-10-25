using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalEnemiesToDefeat = 10; //number of enemies need to die in order to remove the rock from the scene
    public GameObject rock;  //game object to destroy

    private int enemiesDefeated = 0;    //defeated enemy count++

    public void EnemyDefeated()
    {
        //simple count to keep track of enemies defeated
        enemiesDefeated++;
        if (enemiesDefeated >= totalEnemiesToDefeat)
        {
            DestroyObject();
        }
    }

    //Code to then destroy the rock blocking path
    private void DestroyObject()
    {
        if (rock != null)//if rock is there then destroy rock
        {
            Destroy(rock);
        }
    }
}
