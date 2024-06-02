using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class PancingBatu : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public AudioSource audioSource;
    private PlayerMovement playerMovement; 
    public GameObject player; 
    public GameObject BatuPancing;
    public GameObject Batu;
    public static bool pancing = false;

    // Update is called once per frame
    void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) && playerIsClose){
            if(dialoguePanel.activeInHierarchy){
                if(dialogueText.text == dialogue[index]){
                    NextLine();
                }else {
                    StopAllCoroutines();
                    dialogueText.text = dialogue[index];
                    audioSource.Stop();
                }
            }else {     
                playerMovement.SetMovement(false);
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    void Start(){
        dialogueText.text = string.Empty;
        if (audioSource != null)
        {
            audioSource.loop = true;
        }
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void NextLine(){
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else{
            playerMovement.SetMovement(true);
            zeroText();
            pancing = true;
            BatuPancing.SetActive(false);
            Batu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
