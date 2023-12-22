using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePresenter : MonoBehaviour
{

    [SerializeField]
    private Score score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI losePanelScoreText;
    [SerializeField]
    private TextMeshProUGUI losePanelBestText;

    private void Awake()
    {
        score.onScoreAdd += UpdateScoreInGame;
        score.onGameOver += UpdateScoreOnLosePanel;
    }

    private void OnDestroy()
    {
        score.onScoreAdd -= UpdateScoreInGame;
        score.onGameOver -= UpdateScoreOnLosePanel;
    }

    private void UpdateScoreInGame(int score)
    {
        scoreText.text = score.ToString();
        scoreText.GetComponent<Animator>().SetTrigger("ScaleBounce");
    }

    private void UpdateScoreOnLosePanel(int score)
    {
        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetInt("Score", 0);

        if(PlayerPrefs.GetInt("Score") < score)
            PlayerPrefs.SetInt("Score", score);

        losePanelScoreText.text = score.ToString();
        losePanelBestText.text = PlayerPrefs.GetInt("Score").ToString();
    }

}
