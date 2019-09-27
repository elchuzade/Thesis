﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  private float bulletSpeed = 10;
  private int bulletDamage = 10;

  private string direction = "right";
  private string gunDirection = "right";
  private float walkSpeed = 5;
  private int jumpPower = 500;
  private bool jumping;
  private float fireRate = 0.1f;
  [SerializeField] GameObject bulletPrefab;
  private Transform gameSpace;

  Coroutine shootCoroutine;

  void Awake()
  {
    gameSpace = transform.parent.Find("GameSpace");
  }
  void Start()
  {
    Shoot();
  }

  void Update()
  {
    Move();
    Jump();
  }

  private void Shoot()
  {
    shootCoroutine = StartCoroutine(ShootContinuously());
  }

  IEnumerator ShootContinuously()
  {
    while (true)
    {
      GameObject bullet = Instantiate(bulletPrefab, transform.position + GetOffset(gunDirection, gameObject), Quaternion.identity);
      bullet.transform.SetParent(gameSpace);
      PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();
      bulletScript.Create(bulletSpeed, bulletDamage, gunDirection);
      yield return new WaitForSeconds(fireRate);
    }
  }

  private Vector3 GetOffset(string direction, GameObject player)
  {
    Vector3 offset = new Vector3(0, 0, 0);
    RectTransform rt = (RectTransform)player.transform;
    switch (direction)
    {
      case "right":
        offset.x = rt.rect.width / 2;
        break;
      case "left":
        offset.x = -rt.rect.width / 2;
        break;
      case "up":
        offset.y = rt.rect.height / 2;
        break;
      case "down":
        offset.y = -rt.rect.height / 2;
        break;
    }
    return offset;
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
