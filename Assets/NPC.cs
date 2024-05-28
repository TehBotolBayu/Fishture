using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    private bool Spot = false;
    // [SerializeField] List<FishBase> Fish; 
    public Transform player;

    public GameObject dialoguePanel;

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Spot && Input.GetKeyDown(KeyCode.E))
        {
            if(dialoguePanel.activeInHierarchy){

            }else {
                dialoguePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spot = false;
        }
    }

    // public void resetText(){
    //     dialoguePanel.
    // }
}
