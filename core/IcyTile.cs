using UnityEngine;
using System.Collections;

public class IcyTile : MonoBehaviour
{
  private float movementRate;

  private SpriteRenderer renderer;
  private Transform _transform;

  private float destroyYCoord;
  private float startYCoord;

  void Awake ()
  {
    renderer = GetComponent<SpriteRenderer> ();
    _transform = transform;
  }

  void Start ()
  {
    startYCoord = IcyAlpsGameController.Instance.BottomBoundary;
    destroyYCoord = IcyAlpsGameController.Instance.TopBoundary;

    // register with events related to controls
    IcyAlpsBaseControls.SpeedUp  += speedUpTile;
    IcyAlpsBaseControls.SlowDown += slowDownTile;
    PlayerCollisionDetector.PlayerDeath += stopTile;
  }

  // Update is called once per frame
  void Update ()
  {
    if (_transform.position.y >= destroyYCoord) {
      _transform.position = new Vector2 (_transform.position.x, startYCoord);
    } else {
      _transform.position = new Vector2 (_transform.position.x, _transform.position.y + movementRate);
    }
  }

  private void speedUpTile() {
    movementRate = IcyAlpsGameController.Instance.gameSpeed;
  }

  private void slowDownTile() {
    movementRate = IcyAlpsGameController.Instance.gameSpeed;
  }

  private void stopTile() {
    movementRate = 0F;
  }

  public void setSprite(Sprite sprite) {
    renderer.sprite = sprite;
  }
}