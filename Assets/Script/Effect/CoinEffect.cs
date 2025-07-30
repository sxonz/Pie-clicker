using System;
using TMPro;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public int gain;
    public TextMeshProUGUI value;
    float speed = 3;
    RectTransform tr;
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
        tr = GetComponent<RectTransform>();
        value.text = "+" + gain.ToString();
    }
    void Update()
    {
        Vector2 pos = tr.position;
        pos += Vector2.up * speed * Time.fixedDeltaTime;
        speed = Mathf.Max(speed - 0.1f, 0f);
        tr.position = pos;
    }
}
