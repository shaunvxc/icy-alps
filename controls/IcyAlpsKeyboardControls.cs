using UnityEngine;
using System.Collections;

public class IcyAlpsKeyboardControls : IcyAlpsBaseControls
{
  public override bool userInputDetected() {
    return (didLeftControlsFire() || didRightControlsFire());
  }

  public override bool didLeftControlsFire() {
    return Input.GetKey(KeyCode.LeftArrow);
  }

  public override bool didRightControlsFire() {
    return Input.GetKey(KeyCode.RightArrow);
  }
}