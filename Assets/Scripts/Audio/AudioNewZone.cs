using UnityEngine;
using UnityEngine.Audio;

public class AudioNewZone : MonoBehaviour
{
    [SerializeField] AudioSource ForestMusicOST, ForestAmbientOST;

    public void OnForestEnter() {
        ForestMusicOST.Play();
        ForestAmbientOST.Play();
    }

}
