using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeSceneOnvideoEND : MonoBehaviour
{
    private VideoPlayer myPlayer;
    [SerializeField] int index;
    [SerializeField] float time = 0;
    void Start()
    {
        myPlayer = GetComponent<VideoPlayer>();
        //myPlayer.loopPointReached += CheckOver;

    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 10) CheckOver(myPlayer);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(index);
    }
}

