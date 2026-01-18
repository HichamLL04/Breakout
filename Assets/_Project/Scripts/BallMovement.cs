using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject pala;
    [SerializeField] float offsetY = 0.5f;
    [SerializeField] float fuerzaTiro = 2f;
    float nuevaY;
    bool hasStarted = false;
    Rigidbody2D myRb;
    float offsetX;

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
        }
    }

    void OnTrow()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            myRb.linearVelocity = new Vector2(RandomY(), fuerzaTiro);
            Debug.Log("Bola lanzada");
        }
    }

    float RandomY()
    {
        float giro = Random.Range(0.1f, 1f);
        return giro;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lo dejo asi de momento. La intencion es que cada vez que golpe al jugador
            // este agregue fuerza a y para evitar que sea tan recto como pasaba en el pong.
        }
    }
}