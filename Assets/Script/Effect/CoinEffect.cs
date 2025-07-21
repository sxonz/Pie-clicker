using System;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    float speed = 3;
    RectTransform tr;
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
        tr = GetComponent<RectTransform>();
    }
    void Update()
    {
        Vector2 pos = tr.position;
        pos += Vector2.up * speed * Time.fixedDeltaTime;
        speed = Mathf.Max(speed - 0.1f, 0f);
        tr.position = pos;
    }
}
