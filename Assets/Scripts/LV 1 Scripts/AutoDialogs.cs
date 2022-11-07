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
    [SerializeField] GameObject dialoguePlace;
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
        for (int i = 0; i < Dialogues.Length; i++)
        {
            dialoguePlace.GetComponent<TextMeshProUGUI>().text = Dialogues[i];
            yield return new WaitForSeconds(secondsBeforeNextDialgue);
        }
        alreadySaid = true;
        dialoguePlace.SetActive(false);
    }

}
