using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpot : MonoBehaviour
{
    private bool Spot;
    public FishBase[] Fish;
    public GameObject Fishing;
    public PlayerMovement player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Spot)
            {
                player.SetMovement(false);
                FishingSceneData.SetPossibleFish(Fish);
                Fishing.SetActive(true);
            }
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
