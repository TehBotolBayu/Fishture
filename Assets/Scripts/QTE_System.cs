using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QTE_System : MonoBehaviour
{

    public Inventory inventory;
    public InventoryUI inventoryUI;

    public bool masuk;
    public Transform target;
    public Transform targetstart;
    public Transform targetend;
    public Slider progress;
    public GameObject win;
    public Image WinImage;

    private PointerMove pointerMove;

    public GameObject qte;
    public PlayerMovement player;
    public PlayableDirector director;
    public TextMeshProUGUI teksikan;
    public GameObject paktua;

    private void Start()
    {
      
    }

    void Update()
    {
        teksikan.text = FishingSceneData.fish.nama;
        WinImage.sprite = FishingSceneData.fish.image;
        pointerMove = FindObjectOfType<PointerMove>();
        target.localScale = FishingSceneData.target;

        if (progress.value < 1)
        {
            progress.value -= Time.deltaTime * 0.03f;
        }
        else {
            switch (FishingSceneData.fish.nama)
            {
                case "Ikan Prajurit 1" :
                    FishingSpot.ikan1 = true;
                    break;
                case "Ikan Prajurit 2":
                    FishingSpot.ikan2 = true;
                    break;
                case "Ikan Prajurit 3":
                    FishingSpot.ikan3 = true;
                    break;
                case "Ikan Iblis":
                    FishingSpot.ikan4 = true;
                    break;
            }
           
            win.SetActive(true);
        }

        if(progress.value <= 0)
        {
            progress.value = 0.5f;
            qte.SetActive(false);
            player.SetMovement(true);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (masuk)
            {
                if(progress.value < 1)
                {
                    progress.value += 0.2f;
                }
                target.position = new Vector2(Random.Range(targetstart.position.x, targetend.position.x), target.position.y);
                Debug.Log("Berhasil");
            }
            else
            {
                if (progress.value > 0)
                {
                    progress.value -= 0.2f;
                }

                Debug.Log("Gagal");
            }
            
        }

        if(win.activeInHierarchy) {
            if (Input.anyKeyDown)
            {
                if (FishingSpot.ikan4)
                {
                    paktua.transform.position = new Vector3(9.12f, -4.83f, -5.08516f);
                }
                progress.value = 0.5f;
                qte.SetActive(false);
                player.SetMovement(true);
                win.SetActive(false);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        masuk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        masuk = false;
    }

    private void OnDrawGizmos()
    {
        if (target != null && targetstart != null && targetend != null)
        {
            Gizmos.DrawLine(target.transform.position, targetstart.position);
            Gizmos.DrawLine(target.transform.position, targetend.position);
        }
    }
}
