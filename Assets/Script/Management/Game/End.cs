using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string scene;
    public GameObject ScoreManger;
    ClickManager click;
    void Start()
    {
        click = ScoreManger.GetComponent<ClickManager>();
    }

    // Update is called once per frame
    public void end()
    {
        if (click.pi >= 1000)
        {
            click.TrueEnd();
            SceneManager.LoadScene(scene);
        }
    }
}
