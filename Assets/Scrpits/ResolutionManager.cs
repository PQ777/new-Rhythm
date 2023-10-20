using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public int screenWidth = 1200;
    public int screenHeight = 720;
    public bool fullScreen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetResolution()
    {
        Screen.SetResolution(screenWidth, screenHeight, fullScreen);
    }
}
