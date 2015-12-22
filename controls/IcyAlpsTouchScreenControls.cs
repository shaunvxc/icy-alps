using UnityEngine;
using System.Collections;

public class IcyTouchScreenControls : IcyAlpsBaseControls
{

  public override bool isMoving()
  {
    return Input.touchCount > 0;
  }

  public override bool isMovingLeft () {
    return getMovingDirection() == Direction.LEFT;
  }

  public override bool isMovingRight()
  {
    return getMovingDirection() == Direction.RIGHT;
  }
    
  private enum Direction
  {
    NONE,
    LEFT,
    RIGHT,
  }

  private Direction getMovingDirection()
  {
    for (int i = 0; i < Input.touchCount; i++) {

	Touch touch = Input.GetTouch (i);
	Vector2 touchPosition = touch.position;
	touchPosition = Camera.main.ScreenToWorldPoint (touchPosition);

	if (touchPosition.x < 0) {
	  return Direction.LEFT;
	}
	else if (touchPosition.x > 0 ) {
	  return Direction.RIGHT;   
	}
    }

    return Direction.NONE;
  }

}