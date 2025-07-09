using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public Health health;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

//Starts the standard analytics event
    void Start()
    {
        AnalyticsEvent.GameStart();
        Debug.Log("Game Start");
    }

//stops all movement & displays win screen
    public void Win ()
    {
        Time.timeScale = 0;

        UIManager.Instance.showWinScreen();

        AnalyticsEvent.GameOver();
        Debug.Log("Game Over");
    }


//stops all movement on death.Displays death screen
    public void Die()
    {
        Time.timeScale = 0;

        UIManager.Instance.showDieScreen();

        AnalyticsEvent.GameOver();
        Debug.Log("Game Over");
    }    
}
