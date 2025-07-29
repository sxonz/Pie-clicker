using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject ScoreManger;
    ClickManager click;
    Item item;
    void Start()
    {
        item = GetComponent<Item>();
        click = ScoreManger.GetComponent<ClickManager>();
    }

    public void AutoClicker()
    {
        if (click.pi >= 20)
        {
            Debug.Log("개 씨발 왜 안돼");
            click.pi -= 20;
            item.AutoClickerCount++;
        }
    }

    public void ClickBooster()
    {
        if (click.pi >= 20)
        {
            click.pi -= 20;
            item.ClickBoosterCount++;
        }
    }
}
