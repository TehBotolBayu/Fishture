using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Pintukeluar2 : MonoBehaviour
{

// private GameObject playerObj = null;
//     static int posisix = playerObj.transform.position.x;
//     static int posisiy = playerObj.transform.position.y;
    private bool Spot = false;
    // [SerializeField] List<FishBase> Fish; 
    public Transform player;
    public GameObject cam;
    public PlayableDirector director;
    public static bool lokasi;
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        if (Spot)
        {
            player.position = new Vector3(34.65f, 0.5f, 0.0f);
            if (PetaPalsu.peta)
            {
                lokasi = true;
            }
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
