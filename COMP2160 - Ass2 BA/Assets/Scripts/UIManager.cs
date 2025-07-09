using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static private UIManager instance; 
    static public UIManager Instance
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no UIManager present. "); 
            }
            return instance; 
        }
    }

    public GameObject winScreen;
    public GameObject dieScreen;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); 
        }
        else 
        {
            instance = this; 
        }
    }

    void Start()
    {
        winScreen.SetActive(false);
        dieScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    public void showWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void showDieScreen()
    {
        dieScreen.SetActive(true);
    }
}
