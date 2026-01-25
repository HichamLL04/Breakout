using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float speed = 1;
  Rigidbody2D myRb;
  Vector2 moveInput;
  void Start()
  {
    myRb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {

  }

  void OnMove(InputValue value)
  {
    moveInput = value.Get<Vector2>();
    Vector2 playerVelocity = new Vector2(moveInput.x * speed, 0f);
    myRb.linearVelocity = playerVelocity;
  }

  public float GetSpeed()
  {
    return speed;
  }

  public void SetSpeed(float tempSpeed)
  {
    speed = tempSpeed;
  }

  public void SetTransform(Vector3 vector3)
  {
    transform.localScale = vector3;
  }

  public Vector3 GetTransform()
  {
    return transform.localScale;
  }
}
