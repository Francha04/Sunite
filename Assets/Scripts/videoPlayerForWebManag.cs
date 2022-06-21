using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.Video;

public class videoPlayerForWebManag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "SUNITE_ending_sound.mp4");
        this.GetComponent<VideoPlayer>().Play();
    }
}
