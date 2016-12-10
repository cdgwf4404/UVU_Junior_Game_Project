using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

	public int projectileLayer = 12;

	// THESE ARE THE VARIABLES YOU WILL NEED
	public Rigidbody rb; // YOU WILL NEED THIS IF IT IS NOT ALREADY ASSIGNED
	public float knockbackX = 0.5f; //THIS IS THE VARIABLE THAT YOU NEED TO CHANGE DEPENDING ON THE SIDE THEY ARE ON.
	public float knockbackY = 0.5f;
	private Vector2 knockbackSpot;
	public float speed = 2f;
	public float knockbackTime= 1f;


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.layer == projectileLayer) 
		{
			// NEEDED CODE: This is the code that you will add to your detection script.
			knockbackSpot = new Vector3 (transform.position.x + knockbackX, transform.position.y + knockbackY, 1);
			float elapsedTime = 0;
			while (elapsedTime < knockbackTime) 
			{
				transform.position = Vector3.Lerp (transform.position, knockbackSpot, speed*Time.deltaTime);
				elapsedTime += Time.deltaTime;
			}
			// We did this because for some reason the knockback was moving forward.
			transform.position = new Vector3 (transform.position.x, transform.position.y, 1);

			//CODE ENDS HERE
		}
		
	}

	void Start() 
	{
		rb = GetComponentInParent<Rigidbody> ();

	}

}