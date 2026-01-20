using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject pala;
    [SerializeField] float offsetY = 0.5f;
    [SerializeField] float fuerzaTiro = 5f;
    [SerializeField] float velocidadConstante = 5f;
    [SerializeField] HeartBehaviour heartBehaviour;
    
    bool hasStarted = false;
    Rigidbody2D myRb;
    float offsetX;
    float nuevaY;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        offsetX = transform.position.x - pala.transform.position.x;
        nuevaY = pala.transform.position.y + offsetY;
    }

    void Update()
    {
        if (!hasStarted)
        {
            float nuevaX = pala.transform.position.x + offsetX;
            myRb.position = new Vector2(nuevaX, nuevaY);
            myRb.linearVelocity = Vector2.zero;
            myRb.angularVelocity = 0f;
        }
    }

    void FixedUpdate()
    {
        if (!hasStarted) return;
        
        myRb.linearVelocity = myRb.linearVelocity.normalized * velocidadConstante;
        
        float absX = Mathf.Abs(myRb.linearVelocity.x);
        float absY = Mathf.Abs(myRb.linearVelocity.y);
        
        if (absY < 1f)
        {
            float signoY = myRb.linearVelocity.y >= 0 ? 1f : -1f;
            myRb.linearVelocity = new Vector2(myRb.linearVelocity.x, 1f * signoY);
            myRb.linearVelocity = myRb.linearVelocity.normalized * velocidadConstante;
        }
        
        if (absX < 1f) 
        {
            float signoX = myRb.linearVelocity.x >= 0 ? 1f : -1f;
            myRb.linearVelocity = new Vector2(1f * signoX, myRb.linearVelocity.y);
            myRb.linearVelocity = myRb.linearVelocity.normalized * velocidadConstante;
        }
    }

    void OnTrow()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            float randomX = Random.Range(-1f, 1f);
            myRb.linearVelocity = new Vector2(randomX, fuerzaTiro);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float direccionX = Random.Range(0, 2) == 0 ? -1f : 1f;
            myRb.linearVelocity = new Vector2(direccionX * 3f, Mathf.Abs(myRb.linearVelocity.y));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        hasStarted = false;
        heartBehaviour.RestLife();
    }
}