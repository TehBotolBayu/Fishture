using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using System;

public class paktua : MonoBehaviour
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
    public Transform playerPosition;


    // Update is called once per frame
    void Update()
    {
        if(PancingBatu.pancing){
            Array.Resize(ref dialogue, 2);
            dialogue[0] = "Pergilah ke dermaga dan tekan E untuk mulai memancing";
            dialogue[1] = "Kau harus berhasil menangkap semua monster ikan untuk dapat menemukan lokasi raja ikan iblis";
        }
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
            if(!PancingBatu.pancing){
                playerPosition.position = new Vector3(-1.42f, 22.81f, 0.0f);
            }
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
