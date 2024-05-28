using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
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

    private FishBase fish;
    private PointerMove pointerMove;

    public GameObject qte;
    public PlayerMovement player;


    private void Start()
    {
        WinImage.sprite = fish.image;
        pointerMove = FindObjectOfType<PointerMove>();
        fish = pointerMove.GetFish();

        switch (fish.level)
        {
            case 0:
                target.localScale = new Vector3(200, 25, 1);
                break;
            case 1:
                target.localScale = new Vector3(150, 25, 1);
                break;
            default:
                target.localScale = new Vector3(150, 25, 1);
                break;
        }
        
    }

    void Update()
    {
        if(progress.value < 1)
        {
            progress.value -= Time.deltaTime * 0.03f;
        }
        else {
            win.SetActive(true);
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
