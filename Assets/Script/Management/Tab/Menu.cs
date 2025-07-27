using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuTab;
    public void pressed()
    {
        MenuTab.SetActive(!MenuTab.activeSelf);
    }
}
