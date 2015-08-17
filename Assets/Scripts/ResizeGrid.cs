using UnityEngine;
using System.Collections;

public class ResizeGrid : MonoBehaviour {

	[SerializeField] Vector3 gridPos;

	void Update () {
		Vector3 scale = new Vector3 (Camera.main.ScreenToWorldPoint (gridPos).x / transform.GetChild (0).localPosition.x, 
		                             Camera.main.ScreenToWorldPoint (gridPos).x / transform.GetChild (0).localPosition.x, 1);
		Vector3 pos = new Vector3 (0, (Camera.main.ScreenToWorldPoint (gridPos) - (transform.GetChild (0).position - transform.position)).y, 0);

		transform.localScale = scale;
		transform.position = pos;
	}
}
