using System;
using System.Collections.Generic;
using UnityEngine;

public class RightTab : MonoBehaviour
{
    public List<GameObject> RightTabs = new List<GameObject>();
    public List<Animator> Buttons = new List<Animator>();
    int index;

    void Update()
    {
        index = 0;
        foreach (Animator Button in Buttons)
        {
            AnimatorStateInfo stateInfo = Button.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Selected")||stateInfo.IsName("Pressed"))
            {
                RightTabs[index].SetActive(true);
            }
            else
            {
                RightTabs[index].SetActive(false);
            }
            index++;
        }
    }
}
