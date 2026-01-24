using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI HScore;
    [SerializeField] GameObject prefabSpeedUp;
    [SerializeField] GameObject prefabDouble;
    [SerializeField] Transform container;

    ScoreCounting scoreCounting;
    void Start()
    {
        scoreCounting = GetComponent<ScoreCounting>();
    }

    void Update()
    {

    }

    public void CanvasSwitch()
    {
        game.SetActive(false);
        gameOver.SetActive(true);
    }

    public void SaveScore()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", scoreCounting.GetScore());
        }
        else
        {
            if (scoreCounting.GetScore() > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", scoreCounting.GetScore());
            }
        }
        score.text = "SCORE: " + scoreCounting.GetScore().ToString();
        HScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void GeneratePower(string tag, Vector3 position)
    {
        GameObject powerUp = null;

        if (tag.Equals("Orange"))
        {
            powerUp = Instantiate(prefabSpeedUp, position, Quaternion.identity, container);
        }
        else if (tag.Equals("Red"))
        {
            powerUp = Instantiate(prefabDouble, position, Quaternion.identity, container);
        }
    }
}
