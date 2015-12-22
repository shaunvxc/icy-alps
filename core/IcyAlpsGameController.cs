using UnityEngine;
using System.Collections;

public class IcyAlpsGameController : MonoBehaviour
{
    public static IcyAlpsGameController Instance;

    public delegate void TilesDrawnEvent();
    public static event TilesDrawnEvent TilesDrawn;
    
    public Transform baseTile;
    
    public float LeftBoundary;
    public float RightBoundary;
    public float BottomBoundary;
    public float TopBoundary; 

    
    void Awake() { 
	if (Instance == null) { 
	    Instance = this;
	}
    }
    
    void Start () {
	constructLevel ();
	
    }
    
    void Update ()
    {
	
    }
    
    
    private void constructLevel() {
	for (float i = BottomBoundary; i < TopBoundary; i++) {
	    for (float j = LeftBoundary; j < RightBoundary; j++) {
		var tile = ObjectPoolManager.CreatePooled (baseTile.gameObject, new Vector3 (j, i, 2F),  Quaternion.identity);	
	    }
	}
    }
}

