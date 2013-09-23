using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	bool firing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float dirX = Input.GetAxis("Horizontal") * Time.deltaTime;
		float dirY = Input.GetAxis("Vertical") * Time.deltaTime;

		rigidbody.AddRelativeForce(Vector3.up * speed * dirY * Time.deltaTime);
		transform.Rotate(new Vector3(0, 0, -dirX * turnSpeed));
		
		if (Input.GetAxis("Fire1") == 1)
		{
			if (!firing)
			{
				firing = true;
				GameObject bullet = Instantiate(Resources.Load("PlayerBullet"), transform.position, transform.rotation) as GameObject;
			} 
		} else {
			firing = false;
		}
		
		if (transform.position.y < -4)
		{
			Vector3 posYbot = transform.position;
			posYbot.y = 4;
			transform.position = posYbot;
		}
		if (transform.position.y > 4)
		{
			Vector3 posYtop = transform.position;
			posYtop.y = -4;
			transform.position = posYtop;
		}
		if (transform.position.x < -4)
		{
			Vector3 posXlft = transform.position;
			posXlft.x = 4;
			transform.position = posXlft;
		}
		if (transform.position.x > 4)
		{
			Vector3 posXrht = transform.position;
			posXrht.x = -4;
			transform.position = posXrht;
		}
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.collider.tag == Tags.asteroid)
		{
			Destroy(gameObject);
		}
	}
}
