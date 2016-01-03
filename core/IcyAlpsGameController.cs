using UnityEngine;
using System.Collections;

public class IcyAlpsGameController : MonoBehaviour
{
  public static IcyAlpsGameController Instance;

  public Transform baseTile;
  public Transform obstacleTile;

  public float gameSpeed = .04F;

  public float LeftBoundary;
  public float RightBoundary;
  public float BottomBoundary;
  public float TopBoundary;

  private bool playerAlive;
  private int counter = 0;

  private static readonly float _maxSpeed = .15F;
  private static readonly float _minSpeed =  0F;

  void Awake() {
    if (Instance == null) {
      Instance = this;
    }
  }

  void Start () {
    constructLevel ();
    IcyAlpsBaseControls.SpeedUp  += speedUpTile;
    IcyAlpsBaseControls.SlowDown += slowDownTile;
    PlayerCollisionDetector.PlayerDeath += displayGameOverScreen;

    playerAlive = true;
  }

  void Update () {
    // I hate this logic, try and clean it up.
    if(counter == 50) {
      spawnObstacles();
      counter = 0;
    }
    else {
      counter++;
    }
  }

  private void spawnObstacles() {
    if(playerAlive) {
      ObjectPoolManager.CreatePooled(obstacleTile.gameObject, new Vector3 (UnityEngine.Random.Range(LeftBoundary, RightBoundary), BottomBoundary, 2F), Quaternion.identity);
    }
  }

  private void constructLevel() {
    for (float i = BottomBoundary; i < TopBoundary; i++) {
      for (float j = LeftBoundary; j < RightBoundary; j++) {
	ObjectPoolManager.CreatePooled (baseTile.gameObject, new Vector3 (j, i, 2F),  Quaternion.identity);
      }
    }
  }

  private void speedUpTile() {
    if (gameSpeed < _maxSpeed) {
      gameSpeed += .001F;
    }
  }

  private void slowDownTile() {
    if(gameSpeed > _minSpeed) {
      gameSpeed -= .001F;
    }
  }

  private void displayGameOverScreen() {
    Debug.Log("GameOver");
    playerAlive = false;
  }

}