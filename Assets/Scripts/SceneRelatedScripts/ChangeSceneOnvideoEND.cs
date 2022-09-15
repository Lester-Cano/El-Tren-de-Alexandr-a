using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeSceneOnvideoEND : MonoBehaviour
{
    private VideoPlayer myPlayer;
    [SerializeField] int index;
    void Start()
    {
        myPlayer = GetComponent<VideoPlayer>();
        myPlayer.loopPointReached += CheckOver;

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(index);
    }
}

