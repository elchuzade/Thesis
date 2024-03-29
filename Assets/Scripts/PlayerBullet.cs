﻿using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
  private float speed;
  private int damage;
  private string direction;

  void Awake()
  {

  }

  void Start()
  {

  }

  void Update()
  {
    Move();
  }

  private void Move()
  {
    if (direction == "right")
    {
      transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
    }
    else if (direction == "left")
    {
      transform.position = new Vector3(transform.position.x - speed, transform.position.y, 0);
    }
    else if (direction == "up")
    {
      transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
    }
    else if (direction == "down")
    {
      transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
    }
  }

  public void Create(float bulletSpeed, int bulletDamage, string bulletDirection)
  {
    speed = bulletSpeed;
    damage = bulletDamage;
    direction = bulletDirection;
  }

  public int GetDamage()
  {
    return damage;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(gameObject);
  }
}
