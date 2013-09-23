using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.velocity = Vector3.zero;
		
		rigidbody.AddRelativeForce(Vector3.up * 30000 * Time.deltaTime);
	}
}
