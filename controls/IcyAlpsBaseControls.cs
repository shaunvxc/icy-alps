using UnityEngine;
using System.Collections;
/**
 *
 * Base controls script for icy alps
 */
public class IcyAlpsBaseControls : MonoBehaviour
{
  public virtual bool isMoving ()
  {
    Debug.Log ("Error! Using controls script with no implementation of isMoving()-- this means the controls will not be responsive!");
    return false;
  }

  // would be nice to require this method to be overridden!
  public virtual bool isMovingRight () {
    Debug.Log ("Error! Using controls script with no implementation of isMovingRight()-- this means the controls will not be responsive!");
    return false;
  }

  public virtual bool isMovingLeft ()
  {
    Debug.Log ("Error! Using controls script with no implementation of isMovingLeft()-- this means the controls will not be responsive!");
    return false;
  }

  /*
     Events/delegates to manage the speed of the level based on the players behaviors (aka the players controls)
  */

  // these fire when the player straightens out downhill (ie not using the controls )
  public delegate void SpeedUpEvent();
  public static event SpeedUpEvent SpeedUp;

  // these fire when the player is turning (ie touching the screen, turning in some direction
  public delegate void SlowDownEvent();
  public static event SlowDownEvent SlowDown;

  public float movementRate;

  private Transform _transform;
  private SpriteRenderer renderer;
  private Sprite[] sprites;

  private float rotationSpeed = 1.2F;
  public Quaternion localRotation;
  public Vector3 eulerAngles;

  void Awake() {
    sprites = Resources.LoadAll<Sprite> ("SalmonAtlas");
    _transform = transform;
  }

  void Start ()
  {
    renderer = GetComponent<SpriteRenderer> ();
    renderer.sprite = sprites [1];
  }

  void Update ()
  {

    if (isMoving()) {
      if (isMovingLeft()) {
 	moveLeft();
      }
      else if(isMovingRight()) {
	moveRight();
      }
    }
    else {

      // definitely don't NEED this check.. but should double check to make sure that calling Slerp when the object is already in postion
      // does not have any serious overhead
      if (_transform.localRotation.eulerAngles != new Vector3(0, 0, 0))  {
	_transform.rotation = Quaternion.Slerp(_transform.localRotation, new Quaternion(0, 0, 0, 1F), Time.deltaTime * rotationSpeed);
      }

      // speed up once we straighten out!
      if (SpeedUp != null) {
	SpeedUp();
      }
    }
  }

  private void moveLeft() {
    if ( _transform.localRotation.eulerAngles.z > 0F && _transform.localRotation.eulerAngles.z < 180F) {
      _transform.position = new Vector2(_transform.position.x + movementRate, transform.position.y);
      _transform.Rotate(_transform.localRotation * new Vector3(0, 0, -.5F));
      SpeedUp();
    }
    else {
      _transform.position = new Vector2(_transform.position.x - movementRate, transform.position.y);
      _transform.Rotate(_transform.localRotation * new Vector3(0, 0, -.5F));
      SlowDown();
    }
  }

  private void moveRight() {
    if ( _transform.localRotation.eulerAngles.z > 180F && _transform.localRotation.eulerAngles.z < 360F) {
      _transform.position = new Vector2(_transform.position.x - movementRate, transform.position.y);
      _transform.Rotate(_transform.localRotation * new Vector3(0, 0, .5F));
      SpeedUp();
    }
    else {
      _transform.position = new Vector2(_transform.position.x + movementRate, transform.position.y);
      _transform.Rotate(_transform.localRotation * new Vector3(0, 0, .5F));
      SlowDown();
    }
  }
}