using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour {

	[SerializeField] GameObject square; 
	[SerializeField] int gridX = 10;
	[SerializeField] int gridY = 10;

	void Start() {
		for (int x = 0; x < gridX; x++) {
			for (int y = 0; y < gridY; y++){
				GameObject instSquare = (GameObject) Instantiate(square, new Vector3((float) (-(gridX * 0.5 * square.transform.localScale.x) + x * square.transform.localScale.x), 
				                                                        (float) (-(gridY * 0.5 * square.transform.localScale.y) + y * square.transform.localScale.y), 1), Quaternion.identity);
				instSquare.transform.SetParent(transform, true);
			}
		}

		GetComponent<BoxCollider2D> ().size = new Vector2 (gridX, gridY); 
	}
}
