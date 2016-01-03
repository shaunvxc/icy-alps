
using UnityEngine;
using System.Collections;

/**
 *
 * Represents a basic obstacle, which requires box collider, should I use a circle collider?
 *
 */
public class BaseObstacle : IcyTile {

  private BoxCollider2D  collider;

  public void ActivateCollider() {
    collider = GetComponent<BoxCollider2D>();
  }
  
}