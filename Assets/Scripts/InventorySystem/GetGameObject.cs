using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameObject : MonoBehaviour
{
    public Analize analize;
    public GameObject AllanCanvas,AllanCanvas2, AllanInteractButton;

    private void Awake()
    {
        analize = FindObjectOfType<Analize>();
        AllanCanvas = GameObject.Find("MainPanel");
        AllanCanvas2 = GameObject.Find("InventoryPanel");
    }

    public void GoToAnalizeFromMenu()
    {
        analize.GoToAnalizeWithObject(gameObject);
        AllanCanvas.SetActive(false);
        AllanCanvas2.SetActive(false);
    }
}
