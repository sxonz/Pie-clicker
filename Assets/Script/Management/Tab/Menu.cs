using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuTab;
    void pressed()
    {
        MenuTab.SetActive(!MenuTab.activeSelf);
    }
}
