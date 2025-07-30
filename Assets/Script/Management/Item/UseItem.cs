using System.Collections;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    Item item;
    public ClickManager ClickManager;
    public IEnumerator Clickboost()
    {
        ClickManager.boosted += 500;
        yield return new WaitForSeconds(60);
        ClickManager.boosted -= 500;
    }
    public IEnumerator AutoClickboost()
    {
        ClickManager.autoboost += 10000;
        yield return new WaitForSeconds(60);
        ClickManager.autoboost -= 10000;
    }
    void Start()
    {
        item = GetComponent<Item>();
        
    }

    public void AutoClickBooster()
    {
        if (item.AutoClickerCount > 0)
        {
            item.AutoClickerCount--;
            ClickManager.AutoClickBoost();
        }
    }

    public void ClickBooster()
    {
        if (item.ClickBoosterCount > 0)
        {
            item.ClickBoosterCount--;
            StartCoroutine(Clickboost());
        }
    }
}
