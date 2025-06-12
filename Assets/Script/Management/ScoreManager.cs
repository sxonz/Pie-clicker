using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score += 1;
            text.text = score.ToString();
        }
    }
}
