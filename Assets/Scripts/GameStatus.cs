using UnityEngine;

public class GameStatus : MonoBehaviour
{
  private int coins;

  public void AddCoins()
  {
    coins++;
    Debug.Log(coins);
  }
}
