using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Camera : MonoBehaviour
{
    public Transform player;
    public static bool gerak;
    public GameObject lokasipeta;
    private bool kelar;

    void Update()
    {
        if (!gerak)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -5);
            if (Pintukeluar2.lokasi)
            {  
                gerak = true;
                lokasipeta.SetActive(true);

        }
        }
        else
        {
            GetComponent<PlayableDirector>().Resume();
            if (kelar)
            {
                StartCoroutine(waiter());
            }
        }

    }

    public void done()
    {
        kelar = true;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        selesai();
    }



        public void selesai()
    {
        
        Pintukeluar2.lokasi = false;
        gerak = false;
    }

}
