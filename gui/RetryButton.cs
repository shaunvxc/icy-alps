using UnityEngine;
using System.Collections;

public class RetryButton : BaseButton
{

  public override void onClick () {
    Application.LoadLevel (Application.loadedLevel);
  }

}