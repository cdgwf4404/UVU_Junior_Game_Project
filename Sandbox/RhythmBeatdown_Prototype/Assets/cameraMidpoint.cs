using UnityEngine;
using System.Collections;

public class cameraMidpoint : MonoBehaviour {

	public float cameraZOffset, cameraYOffeset, cameraRotate, speed;
	private float distance, midpoint, xDistance;
	private Vector3 cameraPosition;
	public GameObject player1, player2;

	void Start () 
	{
		//Set the y position and x rotation here
		transform.position = new Vector3 ( transform.position.x, cameraYOffeset, transform.position.z);
		transform.eulerAngles = new Vector3 (cameraRotate, transform.rotation.y, transform.rotation.z);
	}

	void FixedUpdate () 
	{
		//Midpoint equals the midpoint between the two players - Distance is the distance between the players and will be used for cameraZPosition
		midpoint = player1.transform.position.x + (player2.transform.position.x - player1.transform.position.x) / 2; 
		distance = Mathf.Abs (Vector3.Distance (player1.transform.position, player2.transform.position));

		//Set cameraPosition according to the variables above and lerp between  those positions
		cameraPosition = new Vector3 ( midpoint, transform.position.y, -distance + cameraZOffset);
		transform.position = Vector3.Lerp (transform.position, cameraPosition, speed*Time.deltaTime);
	}
}
