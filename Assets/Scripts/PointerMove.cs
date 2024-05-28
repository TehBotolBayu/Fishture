using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class PointerMove : MonoBehaviour
{
    public Transform pointer;
    public Transform pointerStart;
    public Transform pointerEnd;
    private float laju;
    int direction = 1;

    private FishBase[] possibleFish;
    private int FishType;
    private FishBase fish;

    public FishBase GetFish()
    {
        return fish;
    }

    private void Start()
    {
        possibleFish = FishingSceneData.GetPossibleFish();
        FishType = Random.Range(0, possibleFish.Length);
        Debug.Log("FishType FishingSpot = " + FishType);
        fish = possibleFish[FishType];
        laju = fish.laju;
    }

    private void Update()
    {
        
        Vector2 target = currentMovementTarget();
        
        pointer.position = Vector2.MoveTowards(pointer.position, target, laju);

        float jarak = (target - (Vector2)pointer.position).magnitude;

        if( jarak <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return pointerStart.position;
        }
        else
        {
            return pointerEnd.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointer != null && pointerStart != null && pointerEnd != null)
        {
            Gizmos.DrawLine(pointer.transform.position, pointerStart.position);
            Gizmos.DrawLine(pointer.transform.position, pointerEnd.position);
        }
    }
}
