using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] corazones;
    int vidasActuales = 2;

    void Start()
    {

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
        Debug.Log("Game Over!");
    }
}