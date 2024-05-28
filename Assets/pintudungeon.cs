using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pintudungeon : MonoBehaviour
{
    private bool Spot = false;
    public Transform player;
    void Update()
    {
            if (Spot)
            {
                player.position = new Vector3(93.21f, -5.52f, 0.0f);
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spot = false;
        }
    }
}
