using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class ClickManager : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI gold_text;
    public TextMeshProUGUI pi_text;

    public TextMeshProUGUI costText;
    public Image costImage;

    public TextMeshProUGUI autoText;
    public Image autoImage;

    public TextMeshProUGUI piText;
    public Camera uicamera;


    public int pi = 0;
    int score = 0;

    int mainIncreasing = 1;
    int accelIncreasing = 0;
    int autoIncreasing = 1000;
    public int autoboost;
    int decreaseVel = 30;
    int curDec = 0;
    public GameObject pi_image;
    public GameObject eff;
    int lasttime;
    public int fuck;
    public GameObject[] nonClickables;

    int level;
    public int maxlevel;
    public int[] Gains;
    public int[] Costs;

    int autoclick;
    int usedautoclickboost;
    public int boosted = 0;

    float pidrop = 0.001f;
    int pilevel = 5;
    public void TrueEnd()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        pi = 0;
        level = 0;
        autoclick = 0;
        pilevel = 1;
    }
    void Read()
    {
        score = PlayerPrefs.GetInt("score");
        pi = PlayerPrefs.GetInt("pi");
        level = PlayerPrefs.GetInt("level");
        autoclick = PlayerPrefs.GetInt("autoclick");
        usedautoclickboost = Mathf.Max(PlayerPrefs.GetInt("used"),1);
        pilevel = Mathf.Max(PlayerPrefs.GetInt("pilevel"),5);
    }
    void Write()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("pi", pi);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("autoclick", autoclick);
        PlayerPrefs.SetInt("used", usedautoclickboost);
        PlayerPrefs.SetInt("pilevel", pilevel);
        
    }
    void Start()
    {
        Read();
        ValueUpdate();
        AutoUpdate();
        LevelUpdate();
        StartCoroutine(AutoClick());
    }
    public void ValueUpdate()
    {
        gold_text.text = score.ToString();
        pi_text.text = pi.ToString();
    }
    public void LevelUpdate()
    {
        decreaseVel = 30 + level * 5;
        mainIncreasing = Gains[level];
        if (level + 1 == maxlevel)
        {
            costText.text = "최대 레벨";
            costImage.gameObject.SetActive(false);
            return;
        }
        costText.text = Costs[level].ToString();
        costImage.gameObject.SetActive(true);
    }
    public void AutoUpdate()
    {
        autoIncreasing = usedautoclickboost * 1000 + autoboost;
        if (autoclick == 1)
        {
            autoText.text = "구매 완료";
            autoImage.gameObject.SetActive(false);
        }
        else
        {
            autoText.text = "10000";
            autoImage.gameObject.SetActive(true);
        }
    }
    public void PiUpdate()
    {
        pidrop = pilevel * 0.001f;
        piText.text = pi.ToString();
    }
    public bool IsPointInside(RectTransform rect, Vector2 screenPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition, uicamera, Vector4.zero);
    }
    public void AutoClickBoost()
    {
        usedautoclickboost += 1;
        AutoUpdate();
    }

    public IEnumerator AutoClick()
    {
        while (true)
        {
            if (autoclick == 1)
                score += autoIncreasing;
            yield return new WaitForSeconds(1);
        }
    }
    public void BuyAutoclick()
    {
        if (score >= 10000 && autoclick == 0)
        {
            autoclick = 1;
            score -= 10000;
        }
     
        AutoUpdate();
    }
    public void PiUpgrade()
    {
        if (pi >= 1)
        {
            pilevel += pi;
            pi -= pi;
        }
    }
    public void CostLevelUp()
    {
        if (level+1 == maxlevel)return;

        if (score >= Costs[level])
        {
            score -= Costs[level];
            level++;
        }

        ValueUpdate();
        LevelUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TrueEnd();
            ValueUpdate();
            LevelUpdate();
            AutoUpdate();
            PiUpdate();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            score += 1000000;
            pi += 1000;
            ValueUpdate();
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            bool flag = true;
            Vector2 mousepos = Input.mousePosition;
            foreach (GameObject nonClickable in nonClickables)
            {
                if (nonClickable.activeSelf)
                {
                    RectTransform nonClickableRect = new RectTransform();
                    if (nonClickable.TryGetComponent<RectTransform>(out nonClickableRect))
                    {
                        flag &= !IsPointInside(nonClickableRect, mousepos);
                    }
                }
            }
            if (flag)
            {
                score += mainIncreasing + accelIncreasing  + boosted;
                GameObject tmp = Instantiate(eff, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                tmp.transform.SetParent(canvas.transform);
                tmp.GetComponent<CoinEffect>().gain = mainIncreasing + accelIncreasing;
                accelIncreasing = Mathf.Min(mainIncreasing * 2, accelIncreasing + 1);
                float v = Random.value;
                if (Random.value <= pidrop)
                {
                    pi += 1;
                }
            }
        }
        else
        {
            if (curDec == decreaseVel)
            {
                accelIncreasing = Mathf.Max(accelIncreasing - 1, 0);
                curDec = 0;
            }
            else
            {
                curDec++;
            }
        }
        pi_image.transform.Rotate(0, 0, -accelIncreasing * Time.deltaTime * 90);
        if (score >= 1000000)
        {
            score -= 1000000;
            pi += 1;
        }
        ValueUpdate();
        AutoUpdate();
        LevelUpdate();
        PiUpdate();
        
    }
    void OnApplicationQuit()
    {
        Write();
    }
}
