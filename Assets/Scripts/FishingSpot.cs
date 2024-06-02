using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpot : MonoBehaviour
{
    private bool Spot;

    public static bool ikan1, ikan2, ikan3, ikan4;

    public FishBase[] Fish;
    public GameObject Fishing;
    public PlayerMovement player;
    public GameObject indikator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Spot)
            {
                player.SetMovement(false);
                FishingSceneData.SetPossibleFish(Fish);
                FishingSceneData.GetRandomFish();
                Fishing.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            indikator.SetActive(true);
            Spot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indikator.SetActive(false);
            Spot = false;
        }
    }
}
