using UnityEngine;

public class GameStatus : MonoBehaviour
{
  private int coins;
  private int score;

  public void AddCoins()
  {
    coins++;
  }

  public void AddScore()
  {
    score++;
  }
}
