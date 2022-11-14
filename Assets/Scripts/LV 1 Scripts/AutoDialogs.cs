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
    [SerializeField] int velState = 0;
    [SerializeField] Button speedButton;

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
        speedButton.gameObject.SetActive(true);
        dialogueCanvasImage.SetActive(true);
       
        player.speed = 0f; //si encuentran una forma de hacer el boton que skipee el dialogo me dicen, porque no se me ocurre sin tener que rehacer todo este script
      
        for (int i = 0; i < Dialogues.Length; i++)
        {
            dialoguePlace.GetComponent<TextMeshProUGUI>().text = Dialogues[i];
            
            yield return new WaitForSeconds(secondsBeforeNextDialgue);
            
            alreadySaid = true;
           
        }
        player.speed = 6;
        
        dialoguePlace.SetActive(false);
        speedButton.gameObject.SetActive(false);
        dialogueCanvasImage.SetActive(false);
       
    }

    public void ChangeVelocity()
    {

        Debug.Log("Cambio velocidad");
        if (velState == 0)
        {
            secondsBeforeNextDialgue = 3;
            speedButton.image.color = Color.blue;
            velState = 1;
        }
        else if (velState == 1)
        {
            secondsBeforeNextDialgue = 1;
            speedButton.image.color = Color.red;
            velState = 2;
        }
        else if (velState == 2)
        {
            secondsBeforeNextDialgue = 6;
            speedButton.image.color = Color.white;
            velState = 0;
        }


    }

}
