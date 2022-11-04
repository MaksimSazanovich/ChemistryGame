using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Networking.UnityWebRequest;

public class Generator : MonoBehaviour
{
    [SerializeField] private double O = 0.000000001;
    [SerializeField] private double N = 0.00000001;
    [SerializeField] private double H = 0.0000001;
    [SerializeField] private double Cl = 0.000001;
    [SerializeField] private double S = 0.00001;
    [SerializeField] private double P = 0.0001;
    [SerializeField] private double Al = 0.001;
    [SerializeField] private double Ca = 0.01;
    [SerializeField] private double Na = 0.1;
    [SerializeField] private double K = 1.0;

    [SerializeField] private int numberOfO;
    [SerializeField] private int numberOfH;
    [SerializeField] private int numberOfS;
    [SerializeField] private int numberOfAl;
    [SerializeField] private int numberOfCa;
    [SerializeField] private int sceneIndex;
    [SerializeField]  private int key;
    double imprecision = 0.000000001;


    Player player;
    Main main;
    Randomazer randomazer;
    Enemy enemy;

    // Randomazer randomazer;
    public double[] keeys = { 2.01e-07, 0.002000003, 1.0204e-05 };
    [SerializeField] private double result;
    [SerializeField] private double nowResult;

    private void Start()
    {
        main = FindObjectOfType<Main>();
        player = FindObjectOfType<Player>();
        randomazer = FindObjectOfType<Randomazer>();
        enemy = FindObjectOfType<Enemy>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        randomazer.GetNumberOfRandom(sceneIndex);

        switch (sceneIndex)
        {
            case 1:
                N = Cl = S = P = Al = Ca = Na = K = 0.0;
                numberOfO = 1;
                numberOfH = 2;
                key = 0;
                imprecision = 0.000000001;
                break;
            case 2:
                N = Cl = P = S = Ca = Na = K = H =  0.0;
                numberOfO = 3;
                numberOfAl = 2;
                key = 1;
                imprecision = 3495.8899;
                break;

        }
        result = 0;
        nowResult = 0;  
        
    }

    public void MixAtoms(int atom)
    {
        switch (atom)
        {
            case 0:
                result += H;
                numberOfH--;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 1:
                result += O;
                numberOfO--;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 2:
                result += Al;
                numberOfAl--;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 3:
                result += Ca;
                numberOfCa--;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 4:
                result += Cl;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 5:
                result += K;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 6:
                result += Na;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 7:
                result += N;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 8:
                result += P;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
            case 9:
                result += S;
                numberOfS--;
                Debug.Log(result);
                CheckAtom();
                CheckWin();
                break;
        }
    }

    private void CheckWin()
    {
                                   
        if (result + imprecision > keeys[key] & result - imprecision < keeys[key])
        {
            Debug.Log("WIN");
            main.ShowWinScreen();
        }
        
    }

    private void CheckAtom()
    {
        switch (sceneIndex)
        {
            case 1:
             if (numberOfH < 0 || numberOfO < 0)
             {
                 SceneManager.LoadScene(sceneIndex);
             }
                else CheckDamage();
                break;
            case 2:
                if (numberOfO < 0 || numberOfAl < 0)
                {
                    SceneManager.LoadScene(sceneIndex);
                }
                else CheckDamage();
                break;
        }
       
        
    }

    private void CheckDamage()
    { 
            double imprecision = 0.00000000000000001;
            if (result + imprecision > nowResult & result - imprecision<nowResult)
            {
                player.TakeDamage();
            }
            else nowResult = result;
    }

    //public void CheckAtomToDestroy()
    //{
    //    if (numberOfAl < 0 || numberOfH < 0 || numberOfO < 0 || numberOfS < 0)
    //    {
    //        enemy.DestroyAtom();
    //    }
    //}

}
