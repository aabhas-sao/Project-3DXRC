using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += WelcomeScene;    
    }

   void WelcomeScene(UnityEngine.Video.VideoPlayer vp) {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       Debug.Log("hi");
   }
}
