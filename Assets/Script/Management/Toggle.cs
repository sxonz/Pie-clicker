using UnityEngine;
using UnityEngine.UI;

public class ToggleMovePanel : MonoBehaviour
{
    public Button moveButton;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    
    }

    public void ToggleMove()
    {
        anim.SetBool("toggle", !anim.GetBool("toggle"));
    }
}
