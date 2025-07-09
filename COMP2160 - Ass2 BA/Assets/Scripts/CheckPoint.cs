using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //creates a link from TrackCheckPoint script and creates a local variable that can be used in checkpoint
    private TrackCheckPoint trackCheckPoint;

    //onTriggerEnter event which rotates through each checkpoint collided with.
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent<PlayerMove2>(out PlayerMove2 player)) 
        {
            trackCheckPoint.CurrentCheckpoint(this);
        }
    }

    public void SetTrackCheckPoints (TrackCheckPoint trackCheckPoint) {
         this.trackCheckPoint = trackCheckPoint;
    }
}


