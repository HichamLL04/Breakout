using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] corazones;
    int vidasActuales = 2;
    bool animando = false;
    Animator animatorActual;
    int indiceActual;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestLife()
    {
        Animator animator = corazones[vidasActuales].GetComponent<Animator>();
        vidasActuales--;
        animator.enabled = enabled;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
    }
}