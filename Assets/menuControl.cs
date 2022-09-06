using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuControl : MonoBehaviour
{
    public Text title;
    int colorChangeInterval = 0;

    byte red = 0;
    byte green = 0;
    byte blue = 0;
    byte alpha = 255;

    int frameCount = 0; // Variable used to pause color changes in Light for the frame count specified with colorChangeInterval

    void Start()
    {
        title.color = new Color(0, 0, 0, 255);
    }
    private void Awake()
    {
 
        red = 255;
        title.color = new Color32(red, green, blue, alpha); // Default color of Light set to RGB(255, 0, 0) 

    }

    // Update is called once per frame
    void Update()
    {
        DoTimedRainbowLightingAnim();
    }

    private void DoTimedRainbowLightingAnim() // Function for calling AnimateLightingInRainbow() in certain frames
    {
        if (colorChangeInterval == 0)
        {
            AnimateLightingInRainbow();
        }
        else if (colorChangeInterval != 0)
        {
            frameCount++; // count how many frames it has been since the last change in Light's color

            if (frameCount == colorChangeInterval)
            {
                AnimateLightingInRainbow();
                frameCount = 0;
            }
        }
    }

    private void AnimateLightingInRainbow() // Function for changing the color of Light 
    {
        // if - else statement that calculates RGB value for the color change 
        if (red == 0 && green == 0 && blue == 0)
            red = 255;
        else if (red == 0 && green < 255 && blue == 255)
            green++;
        else if (red == 0 && green == 255 && blue > 0)
            blue--;
        else if (red == 255 && green == 0 && blue < 255)
            blue++;
        else if (red == 255 && green > 0 && blue == 0)
            green--;
        else if (red > 0 && green == 0 && blue == 255)
            red--;
        else if (red < 255 && green == 255 && blue == 0)
            red++;

        title.color = new Color32(red, green, blue, alpha);

    }


    public void menuSelector(int select)
    {
        switch (select) {
            case 1:

                SceneManager.LoadScene("level");
                break;

            case 2:
                Application.Quit();
                break;
        }
    }
}
