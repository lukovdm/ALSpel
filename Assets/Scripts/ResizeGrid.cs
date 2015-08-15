using UnityEngine;
using System.Collections;

public class ResizeGrid : MonoBehaviour {

	[SerializeField] Vector3 gridPos;
	Camera camera = new Camera();

	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	void Update () {
		Vector3 scale = new Vector3 (camera.ScreenToWorldPoint (gridPos).x / transform.GetChild (0).localPosition.x, 
		                             camera.ScreenToWorldPoint (gridPos).x / transform.GetChild (0).localPosition.x);
		//Vector3 pos = new Vector3 (0, camera.ScreenToWorldPoint(gridPos)
		transform.localScale = scale;
	}
}
