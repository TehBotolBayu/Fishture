using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private PlayableDirector director;
    public GameObject canvas;
    public bool akhir;
    public AudioSource audioSource;
    public GameObject player; // Reference to the player GameObject
    private PlayerMovement playerMovement;
    // Reference to the PlayerMovement script
    public PlayableDirector PaktuaDirector;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        if (audioSource != null)
        {
            audioSource.loop = true;
        }
        // Get reference to the PlayerMovement script
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                audioSource.Stop();
            }

        }
    }

    public void StartDialogue(PlayableDirector pd)
    {
        index = 0;
        StartCoroutine(TypeLine());
        director = pd;
        director.Pause();
        
        // Disable player movement at the start of dialogue
        playerMovement.SetMovement(false);
    }

    IEnumerator TypeLine()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            EndDialogue();
        }
    }
    void EndDialogue()
    {
        if (akhir)
        {
            PaktuaDirector.Resume();
            canvas.SetActive(false);
            director.Stop();
        }
        director.Resume();

        // Enable player movement at the end of dialogue
        playerMovement.SetMovement(true);   
    }
}
