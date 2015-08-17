using UnityEngine;
using System.Collections;

public class DragTouch : MonoBehaviour {

	[SerializeField] LayerMask mask = -1;

	private bool dragging = false;
	private Vector3 offset;
	private Transform toDrag;
	
	void Update() {
		Vector3 v3;
		if (Input.touchCount != 1) {
			dragging = false; 
			return;
		}
		
		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;
		
		if(touch.phase == TouchPhase.Began) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero, Mathf.Infinity, mask);
			Debug.Log("Drag started:" + hit.collider);

			if(hit.collider != null && (hit.collider.tag == "Draggable"))
			{
				Debug.Log("Drag started succes:" + touch.phase);
				toDrag = hit.transform;
				v3 = new Vector3(pos.x, pos.y, 0);
				v3 = Camera.main.ScreenToWorldPoint(v3);
				offset = toDrag.position - v3;
				dragging = true;
			}
		}
		if (dragging && touch.phase == TouchPhase.Moved) {
			Debug.Log("Drag moved:" + touch.phase);
			v3 = new Vector3(pos.x, pos.y, 0);
			v3 = Camera.main.ScreenToWorldPoint(v3);
			toDrag.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			Debug.Log("Drag ended:" + touch.phase);
			dragging = false;
			if (transform.parent != null){
				transform.localPosition = new Vector3(RoundToHalf(transform.localPosition.x), RoundToHalf(transform.localPosition.y), 1);
			}

		}
	}

	float RoundToHalf(float x){
		float y = Mathf.Round (x);
		if (x >= y)
			return y + 0.5f; 
		else
			return y - 0.5f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Grid") {
			transform.SetParent (other.transform);
			transform.localScale = Vector3.one;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Grid") {
			transform.SetParent (null);
			transform.localScale = Vector3.one;
		}
	}
}
