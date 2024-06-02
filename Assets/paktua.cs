using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using System;
using UnityEditor;

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
    public GameObject indikator;
    public Transform PaktuaPosition;
    private PlayableDirector director;


    // Update is called once per frame
    void Update()
    {
           
        if(PancingBatu.pancing){
            if(FishingSpot.ikan1 && FishingSpot.ikan2 && FishingSpot.ikan3)
            {
                Array.Resize(ref dialogue, 3);
                dialogue[0] = "Wah! Kau berhasil menangkap semua prajurit ikan iblis";
                dialogue[1] = "Dengan kemampuanmu saat ini aku yakin kau pasti bisa mengalahkan raja ikan iblis";
                dialogue[2] = "Kau harus ke rumah di timur untuk mengetahui lokasi raja ikan iblis";
            }
            else
            {
                Array.Resize(ref dialogue, 2);
                dialogue[0] = "Pergilah ke dermaga dan tekan 'F' untuk mulai memancing";
                dialogue[1] = "Kau harus berhasil menangkap semua prajurit ikan iblis, setelah itu aku akan memberitahumu lokasi raja ikan iblis";
            }
            
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

    public void stop(PlayableDirector pd)
    {
        director= pd;
        director.Pause();
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
            indikator.SetActive(true);
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            indikator.SetActive(false);
            playerIsClose = false;
            zeroText();
        }
    }
}
