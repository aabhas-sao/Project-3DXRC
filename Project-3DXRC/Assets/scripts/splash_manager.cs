using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class splash_manager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"logo compressed.m4v"); 
        videoPlayer.Play();
        StartCoroutine(wait());
    }

    IEnumerator wait ()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(1);
    }
    
}
