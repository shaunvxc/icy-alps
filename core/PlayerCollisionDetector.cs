using UnityEngine;
using System.Collections;

/**
 *
 * Script to manage collision->player death & broadcast the events to the rest of the system
 */
public class PlayerCollisionDetector : MonoBehaviour {

  /* to broadcast a player death event to the rest of the system */
  public delegate void PlayerDeathEvent();
  public static event PlayerDeathEvent PlayerDeath;

  void OnTriggerEnter2D (Collider2D collision) {
    if (PlayerDeath != null) {
      Debug.Log("A Player death should occur here..");
      PlayerDeath();
    }
  }

}