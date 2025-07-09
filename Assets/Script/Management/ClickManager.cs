using UnityEngine;
using TMPro;
using System;
using System.Net.NetworkInformation;
public class ClickManager : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI text;
    public Camera uicamera;
    int score = 0;
    int mainIncreasing = 1;
    int accelIncreasing = 0;
    int decreaseVel = 10;
    int curDec = 0;
    public GameObject pi;
    public GameObject eff;
    int lasttime;
    public RectTransform mainpanelRect;
    public RectTransform[] nonClickableRects;
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
        text.text = score.ToString();
    }
    public bool IsPointInside(RectTransform rect, Vector2 screenPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition, uicamera, Vector4.zero);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
            score = 0;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            GameObject tmp = Instantiate(eff, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            tmp.transform.SetParent(canvas.transform);
            tmp.GetComponent<RectTransform>();
            bool flag = true;
            Vector2 mousepos = Input.mousePosition;
            for (int i = 0; i < nonClickableRects.Length; i++)
            {
                flag &= !IsPointInside(nonClickableRects[i], mousepos);
            }
            if (IsPointInside(mainpanelRect, Input.mousePosition) && flag)
            {
                score += mainIncreasing + accelIncreasing;
                text.text = score.ToString();
            }
            accelIncreasing = Mathf.Min(mainIncreasing * 2, accelIncreasing + 1);
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
        pi.transform.Rotate(0, 0, -accelIncreasing * Time.deltaTime * 90);
    }
    void OnApplicationQuit()
    {
        Write();
    }
}
