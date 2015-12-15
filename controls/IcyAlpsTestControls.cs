using UnityEngine;
using System.Collections;

public class IcyAlpsTestControls : MonoBehaviour
{
    public float movementRate;

    private Transform _transform;
    private SpriteRenderer renderer;
    private Sprite[] sprites;

    private float rotationSpeed = 1.2F;

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
		// need to update position, rotation & speed when changing controls

		if(touchPosition.x < 0 ) {
		    _transform.position = new Vector2(_transform.position.x - movementRate, transform.position.y);
		    _transform.Rotate(_transform.localRotation * new Vector3(0, 0, -.5F));
		}
		else {
		    _transform.position = new Vector2(_transform.position.x + movementRate, transform.position.y);
		    _transform.Rotate(_transform.localRotation * new Vector3(0, 0, .5F));
		}
	    }
	}
	else {
	    // definitely don't NEED this check.. but should double check to make sure that calling Slerp when the object is already in postion
	    // does not have any serious overhead
	    if (_transform.localRotation.eulerAngles != new Vector3(0, 0, 0))  {
		_transform.rotation = Quaternion.Slerp(_transform.localRotation, new Quaternion(0, 0, 0, 1F), Time.deltaTime * rotationSpeed);
	    }
	}
    }
}
