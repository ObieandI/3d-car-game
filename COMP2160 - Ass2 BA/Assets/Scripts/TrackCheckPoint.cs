using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPoint : MonoBehaviour
{
    private List<CheckPoint> checkpointList;
    private int nextCheckpoint;
    private bool correctCheckpoint = false;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("/GameManager").GetComponent<GameManager>();
    }

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("CheckPoints");

        checkpointList = new List<CheckPoint>();
        foreach (Transform checkpointTransform in checkpointsTransform)
        {
            CheckPoint checkPoint = checkpointTransform.GetComponent<CheckPoint>();

            checkPoint.SetTrackCheckPoints(this);
            checkpointList.Add(checkPoint);
        }

        nextCheckpoint = 0;
    }

    public void CurrentCheckpoint(CheckPoint checkPoint)
    {
        if (checkpointList.IndexOf(checkPoint) == nextCheckpoint)
        {
            Debug.Log("Correct Way");
            nextCheckpoint++;
            correctCheckpoint = true;
        }
        else
        {
            Debug.Log("Wrong Way");
            correctCheckpoint = false;
        }
        
        if (checkpointList.IndexOf(checkPoint) == 2 && correctCheckpoint == true)
        {
            gameManager.Win();
            Debug.Log("You Win!");

        }
    }
}
