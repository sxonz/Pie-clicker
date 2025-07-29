using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public List<string> Messages;
    public TextMeshProUGUI text;
    float t = 0f;
    int index = 0;
    void Update()
    {
        if (index < Messages.Count)
        {
            t += Time.deltaTime;
            text.text = Messages[index];
            if (t > 3)
            {
                t = 0;
                index++;
            }
        }
    }
}
