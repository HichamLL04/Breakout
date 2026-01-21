using UnityEngine;

public class BrickActivity : MonoBehaviour
{
    Animator animator;
    ScoreCounting scoreCounting;
    void Start()
    {
        scoreCounting = FindFirstObjectByType<ScoreCounting>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = true;
        string tag = gameObject.tag;
        float duracion = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, duracion);
        scoreCounting.IncreaseScore(tag);
    }
}
