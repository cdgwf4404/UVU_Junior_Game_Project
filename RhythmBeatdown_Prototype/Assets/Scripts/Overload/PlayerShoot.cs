using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	public Rigidbody projectile;
	public float bulletSpeed = 15f;

//Player shooting bullets
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Rigidbody instantiateProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;
			
			//instantiate bullet from PreFabs 
			
			instantiateProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, bulletSpeed));
		}		
	}	
}
