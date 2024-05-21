using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStart()
    {
        Time.timeScale = 1.0f;
        Destroy(this);
        SceneManager.LoadScene("Jin_MainScene");
    }

    public void GoStart()
    {
        Time.timeScale = 1.0f;
        Destroy(this);
        SceneManager.LoadScene("Jin_StartScene");
    }
    public void Continue()
    {
        Time.timeScale = 1.0f;
        Destroy(transform.parent.gameObject);
    }
    public void Pause()
    {
        if (Time.timeScale == 1.0f && !GameManager.Instance.isGameOver)
        {
            Instantiate(GameManager.Instance.PauseMenu, GameObject.Find("Canvas").transform);
        }
    }
}
