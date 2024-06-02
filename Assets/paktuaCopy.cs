using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using System;

public class paktuaCopy : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue = new string[2];
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public AudioSource audioSource;
    private PlayerMovement playerMovement; 
    public GameObject player; 
    public Transform playerPosition;
    public Transform pakTua;
    public GameObject indikator;
    public GameObject ending;
    public AudioSource musicsource;


    // Update is called once per frame
    void Update()
    {
        if(PancingBatu.pancing){
            Array.Resize(ref dialogue, 8);
            dialogue[0] = "Wah ternyata ramalan itu nyata. Seseorang dari dunia lain datang untuk menyelamatkan dunia ikan.!";
            dialogue[1] = "Dunia ikan telah mengalami kehancuran semenjak raja ikan iblis bangkit.";
            dialogue[2] = "Raja ikan iblis bersama pasukannya datang. Mereka menenggelamkan kota demi kota";
            dialogue[3] = "hingga yang tersisa didunia ini hanyalah pulau pulau kecil yang dihuni kaum terakhir dari kami.";
            dialogue[4] = "Hanya ada satu cara untuk mengalahkan raja ikan iblis, yaitu dengan memancingnya keluar dari lingkungan hidupnya";
            dialogue[5] = "dengan menggunakan pusaka pancing legendaris";
            dialogue[6] = "yang konon hanya dapat digunakan oleh manusia terpilih";
            dialogue[7] = "Kau lah orang itu!";
            if (FishingSpot.ikan4)
            {
                Array.Resize(ref dialogue, 3);
                dialogue[0] = "Terima Kasih! kau telah menyelamatkan dunia ini dari invasi Raja Ikan Iblis";
                dialogue[1] = "Dunia ikan akan kembali dalam kedamai...";
                dialogue[2] = "!?!?";
            }

        } else {
            Array.Resize(ref dialogue, 2);
            dialogue[0] = "Masuklah, didalam pusaka suci telah menunggumu";
            dialogue[1] = "Semoga dewa neptunus memberkatimu";
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
            if(PancingBatu.pancing){
                if (FishingSpot.ikan4)
                {
                    ending.SetActive(true);
                    musicsource.Play();
                    
                }
                else
                {
                    playerPosition.position = new Vector3(15.22f, 7.31f, 0.0f);
                    pakTua.position = new Vector3(15f, 5f, 0.0f);
                }
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
            playerIsClose = false;
            indikator.SetActive(false);
            zeroText();
        }
    }
}
