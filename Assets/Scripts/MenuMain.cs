using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
       levelManager = FindObjectOfType<LevelManager>();
    }
    public void NextLevel()
    { 
    levelManager.NextLevel();
    }
}
