using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public float timer;
    public float refresh;
    public float avgFramerate;
    public Text fpstext;

    void Start()
    {
        
    }

    void Update()
    {
        //calculating and converting the fps to a string to be displayed
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;
        if(timer <= 0) avgFramerate = (int)(1f / timelapse);
        fpstext.text ="Framerate; "+ avgFramerate.ToString() + " FPS";
    }
}
