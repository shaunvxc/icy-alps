using UnityEngine;
using System.Collections;

public class IcyAlpsTestControls : MonoBehaviour
{

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
    if (Input.touchCount > 0) {
      for (int i = 0; i < Input.touchCount; i++) {

	Touch touch = Input.GetTouch (i);
	Vector2 touchPosition = touch.position;

	touchPosition = Camera.main.ScreenToWorldPoint (touchPosition);

	// Need to improve the physics for turning...
	if(touchPosition.x < 0 ) {
	  moveLeft();
	}
	else {
	  moveRight();
	}

	// localRotation = _transform.localRotation;
	// eulerAngles = _transform.localRotation.eulerAngles;
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