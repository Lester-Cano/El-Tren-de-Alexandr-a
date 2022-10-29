using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource SFXSource;
    private void Start() {
        GetComponent<AudioSource>();
    }
}
