using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private int healthPoints = 5;

  private void DecreaseHealth(int damage)
  {
    healthPoints -= damage;
    if (healthPoints <= 0)
    {
      KillEnemy();
    }
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "PlayerBullet")
    {
      DecreaseHealth(collision.gameObject.GetComponent<PlayerBullet>().GetDamage());
    }
  }
  private void KillEnemy()
  {
    Destroy(gameObject);
  }

}
