using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeonkeluar : MonoBehaviour
{

// private GameObject playerObj = null;
//     static int posisix = playerObj.transform.position.x;
//     static int posisiy = playerObj.transform.position.y;
    private bool Spot = false;
    // [SerializeField] List<FishBase> Fish; 
    public Transform player;
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
            if (Spot)
            {
                player.position = new Vector3(-1.5f, 25f, 0.0f);
                // SceneManager.LoadScene(4);
            }
        // }
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
