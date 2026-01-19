using UnityEngine;

public class BrickActivity : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = true;
        float duracion = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, duracion);
    }
}
