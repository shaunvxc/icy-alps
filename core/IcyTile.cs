using UnityEngine;
using System.Collections;

public class IcyTile : MonoBehaviour
{

  private float movementRate = .02F;

  private SpriteRenderer renderer;
  private Transform _transform;
  private  float   destroyYCoord;
  private  float   startYCoord;

  private bool active;

  private static readonly float _maxSpeed = .1F;
  private static readonly float _minSpeed =  0F;

    
  void Awake ()
  {
    renderer = GetComponent<SpriteRenderer> ();
    _transform = transform;
  }

  void Start ()
  {
    startYCoord = IcyAlpsGameController.Instance.BottomBoundary;
    destroyYCoord = IcyAlpsGameController.Instance.TopBoundary;

    IcyAlpsBaseControls.SpeedUp  += speedUpTile;
    IcyAlpsBaseControls.SlowDown += slowDownTile;
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

  void speedUpTile() {
    if (movementRate < _maxSpeed) {
      movementRate += .0005F;
    }
  }

  void slowDownTile() {
    if(movementRate > _minSpeed) {
      movementRate -= .0005F;
    }
  }
    
  public void setSprite(Sprite sprite) {
    renderer.sprite = sprite;
  }

}
