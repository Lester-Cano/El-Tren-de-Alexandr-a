using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class AutoDialogs : MonoBehaviour
{
    [SerializeField] string[] dialogue;
    [SerializeField] bool alreadySaid;
    [SerializeField] GameObject dialogueCanvas;
    MovementController player;
    private TMP_Text canvasText;

    //Letter Writer Area

    private int count = 0;
    [SerializeField] private float textSpeed;
    private string currentText = "";
    private bool writing;
    private float initialTextSpeed;
    [SerializeField] FeedbackTalk feedbackTalk;

    //Buttons

    private Button nextB, stopB;

    private void Awake()
    {
        player = FindObjectOfType<MovementController>();
        canvasText = GameObject.Find("AutoDialogPlace").GetComponent<TMP_Text>();
        nextB = GameObject.Find("NextBAuth").GetComponent<Button>();
        stopB = GameObject.Find("SkipBAuth").GetComponent<Button>();
    }
    private void Start()
    {
        dialogueCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !alreadySaid)
        {
            nextB.onClick.AddListener(NextText);
            stopB.onClick.AddListener(StopTalking);
            StartText();
        }
    }

    public void StartText()
    {
        alreadySaid = true;

        dialogueCanvas.SetActive(true);
        player.speed = 0f;
      
        for (int i = 0; i < dialogue.Length; i++)
        {
            if (dialogue != null)
            {
                if (!writing) StartCoroutine(WriteText());
            }
            else
            {
                StopTalking();
            }                       
        }    
    }

    public void NextText()
    {
        if (writing)
        {
            textSpeed = 0;
        }
        else if (dialogue != null)
        {
            feedbackTalk.StopTween();
            textSpeed = initialTextSpeed;
            count++;
            if (count < dialogue.Length)
            {
                writing = true;
                StartCoroutine(WriteText());
            }
            else
            {
                StopTalking();
            }
        }
        else if (dialogue == null)
        {
            StopTalking();
        }
    }

    IEnumerator WriteText()
    {
        feedbackTalk.StopTween();
        writing = true;
        for (int i = 0; i < dialogue[count].Length; i++)
        {
            currentText = dialogue[count].Substring(0, i);
            canvasText.text = currentText;
            if (i + 1 == dialogue[count].Length)
            {
                writing = false;
                feedbackTalk.TweenArrow();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void StopTalking()
    {
        player.speed = 6;
        nextB.onClick.RemoveListener(NextText);
        stopB.onClick.RemoveListener(StopTalking);

        canvasText.text = null;
        count = 0;

        dialogueCanvas.SetActive(false);
    }
}
