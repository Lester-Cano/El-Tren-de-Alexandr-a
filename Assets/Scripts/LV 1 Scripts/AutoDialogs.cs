using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AutoDialogs : MonoBehaviour
{
    [SerializeField] string[] Dialogues;
    [SerializeField] int secondsBeforeNextDialgue;
    [SerializeField] bool alreadySaid;
    [SerializeField] GameObject dialoguePlace, dialogueCanvasImage;
    MovementController player;
    private void Awake()
    {
        player = FindObjectOfType<MovementController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !alreadySaid)
        {
            StartCoroutine(StartText());
        }
    }

    IEnumerator StartText()
    {
        dialoguePlace.SetActive(true);
        dialogueCanvasImage.SetActive(true);
        player.speed = 0;
      
        for (int i = 0; i < Dialogues.Length; i++)
        {
            dialoguePlace.GetComponent<TextMeshProUGUI>().text = Dialogues[i];
            yield return new WaitForSeconds(secondsBeforeNextDialgue);
            alreadySaid = true;
        }
        player.speed = 6;
        
        dialoguePlace.SetActive(false);
        dialogueCanvasImage.SetActive(false);
    }

}
