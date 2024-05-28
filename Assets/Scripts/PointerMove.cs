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
    int direction = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log("Ikan Apa Nih = " + FishingSceneData.fish.nama);
        Vector2 target = currentMovementTarget();
        
        pointer.position = Vector2.MoveTowards(pointer.position, target, FishingSceneData.fish.laju);

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
