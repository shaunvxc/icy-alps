using UnityEngine;
using System.Collections;

public class IcyTile : MonoBehaviour
{

    public float movementRate;

    private SpriteRenderer renderer;
    private Transform _transform;

    private  float   destroyYCoord;
    private  float   startYCoord;

    private bool active;

    void Awake ()
    {
	renderer = GetComponent<SpriteRenderer> ();
	_transform = transform;
    }

    void Start ()
    {
	startYCoord = IcyAlpsGameController.Instance.BottomBoundary;
	destroyYCoord = IcyAlpsGameController.Instance.TopBoundary;
	// IcyAlpsGameController.TilesDrawn += startTiles;
    }

    // Update is called once per frame
    void Update ()
    {
	if (_transform.position.y >= destroyYCoord) {
	    _transform.position = new Vector2 (_transform.position.x, startYCoord);
	} else {
	    _transform.position = new Vector2 (_transform.position.x, _transform.position.y + movementRate);
	}
    }

    // can this be private?
    // void startTiles() {
    // 	Debug.Log("Starting up tiles");
    // 	active = true;
    // }

    public void setSprite(Sprite sprite) {
	renderer.sprite = sprite;
    }

}
