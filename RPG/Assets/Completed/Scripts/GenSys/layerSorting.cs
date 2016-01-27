using UnityEngine;
using System.Collections;

public class layerSorting : MonoBehaviour
{
	public int topOrder = 3;
	public int bottomOrder = 1;
	public float objectRange = 0.3f;
	public bool playerInCollider = false;
	private SpriteRenderer sprite;
	public float playerPos = 0.2f;
	public float objectPos = 0.1f;

	public PlayerController playerCtrl;
	
	void Start ()
	{
		sprite = GetComponent<SpriteRenderer>();
		GameObject g = GameObject.Find("Player");
		playerCtrl = g.GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player")
		{
			// ... move the object above its sorting number.
			StartCoroutine("DetermineLayerPosition");
		}
	}

	IEnumerator DetermineLayerPosition()
	{
		yield return null;
		playerPos = GameObject.Find ("Player").transform.position.y;
		objectPos = this.transform.position.y;
		playerInCollider = true;
		if (playerPos > objectPos) {
			sprite.sortingOrder = topOrder;
		} else {
			sprite.sortingOrder = bottomOrder;
		}
	}
}