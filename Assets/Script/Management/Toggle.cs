using UnityEngine;
using UnityEngine.UI;

public class ToggleMovePanel : MonoBehaviour
{
    public Button moveButton;
    public RectTransform panel;

    public float moveDistance = 200f; // 이동 거리
    private Vector2 originalPosition;
    private bool isMoved = false;

    void Start()
    {
        originalPosition = panel.anchoredPosition;
        moveButton.onClick.AddListener(ToggleMove);
    }

    void ToggleMove()
    {
        if (!isMoved)
        {
            panel.anchoredPosition = new Vector2(originalPosition.x + moveDistance, originalPosition.y);
            isMoved = true;
        }
        else
        {
            panel.anchoredPosition = originalPosition;
            isMoved = false;
        }
    }
}
