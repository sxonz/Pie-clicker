using UnityEngine;
using TMPro;
public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Camera uicamera;
    int score = 0;
    public RectTransform mainpanelRect;
    public RectTransform[] nonClickableRects;
    void Start()
    {

    }
    public bool IsPointInside(RectTransform rect, Vector2 screenPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition, uicamera,Vector4.zero);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            bool flag = true;
            Vector2 mousepos = Input.mousePosition;
            for(int i = 0;i<nonClickableRects.Length; i++)
            {
                flag &= !IsPointInside(nonClickableRects[i], mousepos);
            }
            if (IsPointInside(mainpanelRect, Input.mousePosition) && flag)
            {
                score += 1;
                text.text = score.ToString();
            }
        }
    }
}
