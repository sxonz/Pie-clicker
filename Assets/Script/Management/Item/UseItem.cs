using UnityEngine;

public class UseItem : MonoBehaviour
{
    Item item;
    void Start()
    {
        item = GetComponent<Item>();
    }

    public void AutoClicker()
    {
        if (item.AutoClickerCount > 0)
        {
            item.AutoClickerCount--;
            //오토 클릭 기능들
        }
    }

    public void ClickBooster()
    {
        if (item.ClickBoosterCount > 0)
        {
            item.ClickBoosterCount--;
            //클릭 부스터 기능들
        }
    }
}
