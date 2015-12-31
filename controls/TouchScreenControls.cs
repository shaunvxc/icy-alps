using UnityEngine;
using System.Collections;

public class TouchScreenControls : IcyAlpsBaseControls
{

  public override bool userInputDetected() {
    return Input.touchCount > 0;
  }

  public override bool didLeftControlsFire() {
    return getMovingDirection() == Direction.LEFT;
  }

  public override bool didRightControlsFire() {
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
	Vector2 touchPosition = Camera.main.ScreenToWorldPoint (touch.position);

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