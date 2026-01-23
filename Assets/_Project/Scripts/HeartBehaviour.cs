using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] corazones;
    GameManager gameManager;
    int vidasActuales = 2;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {

    }

    public void RestLife()
    {
        if (vidasActuales >= 1)
        {
            Animator animator = corazones[vidasActuales].GetComponent<Animator>();
            vidasActuales--;
            animator.enabled = enabled;
        }
        else
        {
            GameOver();
        }

    }

    void GameOver()
    {
        gameManager.SaveScore();
        gameManager.CanvasSwitch();
    }
}