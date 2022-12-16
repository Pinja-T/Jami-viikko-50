using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject optionsPanel;
   


    public void GoToMain()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
   
    }

    public void GoToOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    List<int> widths = new List<int>() { 800, 1280, 1920 };
    List<int> heights = new List<int>() { 600, 800, 1080 };

    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullScreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }




}
