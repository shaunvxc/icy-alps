using UnityEngine;
using System.Collections;

public class IcyAlpsKeyboardControls : IcyAlpsBaseControls
{
  public override bool isMoving()
  {
    return (isMovingLeft() || isMovingRight());
  }

  public override bool isMovingLeft () {
    return Input.GetKey(KeyCode.LeftArrow);
  }

  public override bool isMovingRight()
  {
    return Input.GetKey(KeyCode.RightArrow);
  }
}