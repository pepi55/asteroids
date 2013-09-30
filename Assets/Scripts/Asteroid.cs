using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float size;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.velocity = Vector3.zero;
		
		rigidbody.AddRelativeForce(Vector3.up * 3000 * Time.deltaTime);
		
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
	
	void OnTriggerEnter (Collider collision) {
		if (collision.collider.tag == Tags.bullet)
		{
			Destroy(gameObject);
			
			Instantiate(Resources.Load("Asteroid" + size), transform.position, Quaternion.identity);
		}
	}
}
