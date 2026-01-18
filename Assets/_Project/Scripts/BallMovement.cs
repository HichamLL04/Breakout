using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject pala;
    [SerializeField] float offsetY = 0.5f;
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
}