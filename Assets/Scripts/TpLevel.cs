using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpLevel : MonoBehaviour
{
    [SerializeField] int levelIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeSceneByIndex(levelIndex);
        }
    }
    public void ChangeSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
