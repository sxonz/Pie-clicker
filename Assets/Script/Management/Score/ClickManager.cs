using UnityEngine;
using TMPro;
using System;
using System.Net.NetworkInformation;
public class ClickManager : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI gold_text;
    public TextMeshProUGUI pi_text;
    public Camera uicamera;

    public int pi = 0;
    int score = 0;

    int mainIncreasing = 1;
    int accelIncreasing = 0;
    int decreaseVel = 10;
    int curDec = 0;
    public GameObject pi_image;
    public GameObject eff;
    int lasttime;
    public GameObject[] nonClickables;
    void Read()
    {
        score = PlayerPrefs.GetInt("score");
    }
    void Write()
    {
        PlayerPrefs.SetInt("score", score);
    }
    void Start()
    {
        Read();
        gold_text.text = score.ToString();
    }
    public bool IsPointInside(RectTransform rect, Vector2 screenPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition, uicamera, Vector4.zero);
    }

    void Update()
    {
        pi_text.text = pi.ToString();
        gold_text.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
            score = 0;
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
                score += mainIncreasing + accelIncreasing;
                GameObject tmp = Instantiate(eff, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                tmp.transform.SetParent(canvas.transform);
                tmp.GetComponent<RectTransform>();
                accelIncreasing = Mathf.Min(mainIncreasing * 2, accelIncreasing + 1);
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
    }
    void OnApplicationQuit()
    {
        Write();
    }
}
