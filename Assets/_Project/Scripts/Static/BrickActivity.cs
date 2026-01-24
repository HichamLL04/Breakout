using UnityEngine;

public class BrickActivity : MonoBehaviour
{
    Animator animator;
    ScoreCounting scoreCounting;
    BoxCollider2D boxCollider2D;
    GameManager gameManager;
    void Start()
    {
        scoreCounting = FindFirstObjectByType<ScoreCounting>();
        animator = GetComponent<Animator>();
        gameManager = FindFirstObjectByType<GameManager>();
        animator.enabled = false;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = true;
        string tag = gameObject.tag;
        float duracion = animator.GetCurrentAnimatorStateInfo(0).length;
        boxCollider2D.enabled = false;
        Destroy(gameObject, duracion);
        BrickRowManager.OnBrickDestroyed();
        gameManager.GeneratePower(tag, transform.position);
        scoreCounting.IncreaseScore(tag);
    }
    
}