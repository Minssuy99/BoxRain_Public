using UnityEngine;
using UnityEngine.UI;

public class PlayersScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private void Start()
    {
        ShowHighScore();
    }
    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        scoreText.text = $"현재 점수 : {GameManager.Instance.score}";
    }
    private void ShowHighScore()
    {
        if (GameManager.Instance.saveSystem.Load() == null)
        {
            highScoreText.text = "최고 점수 : 0";
        }
        else
        {
            highScoreText.text = $"최고 점수 : {GameManager.Instance.saveSystem.Load().highscore}";
        }        
    }
}