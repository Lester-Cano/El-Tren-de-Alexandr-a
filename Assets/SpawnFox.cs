using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFox : MonoBehaviour
{
    [SerializeField] GameObject Fox;
    int index;
   public void SpawningFox(Transform[] spawns)
    {
        Fox.SetActive(true);
        index = Random.Range(0,spawns.Length);
        Fox.GetComponent<Transform>().position = spawns[index].position;
    }
}
