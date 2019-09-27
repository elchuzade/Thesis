using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  private string direction = "right";
  private string gunDirection = "right";
  private float walkSpeed = 1;
  private int jumpPower = 100;
  private bool jumping;

  void Start()
  {

  }

  void Update()
  {
    Move();
    Jump();
  }

  private void Move()
  {
    if (Input.GetKey("right"))
    {
      gunDirection = "right";
      direction = "right";
      transform.position = new Vector3(transform.position.x + walkSpeed, transform.position.y, 0);
    }
    if (Input.GetKey("left"))
    {
      gunDirection = "left";
      direction = "left";
      transform.position = new Vector3(transform.position.x - walkSpeed, transform.position.y, 0);
    }
    if (Input.GetKey("up"))
    {
      gunDirection = "up";
    }
    if (Input.GetKey("down"))
    {
      gunDirection = "down";
    }
  }

  private void Jump()
  {
    if (Input.GetKey("space") && !jumping)
    {
      jumping = true;
      GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Platform")
    {
      jumping = false;
    }
  }
}
