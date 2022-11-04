using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private int direction;

    [SerializeField] private int health;

    Main main;
    LevelManager levelManager;
    MainCamera mainCamera;

    
    

    void Start()
    {
        direction = 0;
        main = FindObjectOfType<Main>();
        levelManager = FindObjectOfType<LevelManager>();
        mainCamera = FindObjectOfType<MainCamera>();    
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * turnSpeed * direction * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health--;
        mainCamera.PlayCameraShaking();
        main.ChangeHealthDisplay(health);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            levelManager.ReloadScene();
        }
    }

    public void OnRightButtonDown()
    {
        if (direction >= 0)
        {
            direction = 1;
        }
    }

    public void OnLeftButtonDown()
    {
        if (direction <= 0)
        {
            direction = -1;
        }
    }

    public void OnButtonUp()
    {
        direction = 0;
    }
}
