using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public TextMeshProUGUI AutoCount_TXT;
    public int AutoClickerCount = 0;

    public TextMeshProUGUI BoosterCount_TXT;
    public int ClickBoosterCount = 0;
    void Start()
    {

    }

    void Update()
    {
        AutoCount_TXT.text = "보유횟수 : " + AutoClickerCount.ToString();
        BoosterCount_TXT.text = "보유횟수 : " + ClickBoosterCount.ToString();
    }
}
