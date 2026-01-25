using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI HScore;
    [SerializeField] GameObject[] prefabPowerUp;
    [SerializeField] Transform container;
    [SerializeField] AudioClip backgroundSong;
    [SerializeField] GameObject ballPrefab;

    AudioSource audioSource;
    ScoreCounting scoreCounting;
    PlayerMovement playerMovement;

    void Start()
    {
        scoreCounting = GetComponent<ScoreCounting>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        StartSong(backgroundSong);
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
        //StopSong();
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
        if (tag.Equals("Orange"))
        {
            Instantiate(prefabPowerUp[0], position, Quaternion.identity, container);
        }
        else if (tag.Equals("Red"))
        {
            Instantiate(prefabPowerUp[1], position, Quaternion.identity, container);
        }
        else if (tag.Equals("Yellow"))
        {
            Instantiate(prefabPowerUp[2], position, Quaternion.identity, container);
        }
        else if (tag.Equals("Purple"))
        {
            Instantiate(prefabPowerUp[3], position, Quaternion.identity, container);
        }
    }

    void StartSong(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void StopSong()
    {
        audioSource.Stop();
    }

    public void RespawnBall()
    {
        GameObject pala = GameObject.FindGameObjectWithTag("Player");
        Vector3 newPos = pala.transform.position + new Vector3(Random.Range(-1f, 1f), 2f, 0f);
        Instantiate(ballPrefab, newPos, Quaternion.identity, container);
    }

    public Transform GetContainer()
    {
        return container;
    }
}