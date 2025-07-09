using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    float speed = 0.02f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = GetComponent<RectTransform>().position;
        pos += Vector2.up * speed;
        speed = Mathf.Max(speed - 0.001f, 0f);
        GetComponent<RectTransform>().position = pos;
    }
}
