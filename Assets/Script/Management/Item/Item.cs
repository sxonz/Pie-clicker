using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{

    public TextMeshProUGUI AutoCount_TXT;
    public int AutoClickerCount = 0;

    public TextMeshProUGUI BoosterCount_TXT;
    public int ClickBoosterCount = 0;
    void Write()
    {
        PlayerPrefs.SetInt("autoclick", AutoClickerCount);
        PlayerPrefs.SetInt("clickboost", ClickBoosterCount);
    }
    void Start()
    {
        AutoClickerCount = PlayerPrefs.GetInt("autoclick");
        ClickBoosterCount = PlayerPrefs.GetInt("clickboost");
    }

    void Update()
    {
        AutoCount_TXT.text = "보유 : " + AutoClickerCount.ToString();
        BoosterCount_TXT.text = "보유 : " + ClickBoosterCount.ToString();
        Write();
    }
}
