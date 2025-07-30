using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        source.volume = slider.value;
        text.text = ((int)(slider.value * 100)).ToString();
    }
}
