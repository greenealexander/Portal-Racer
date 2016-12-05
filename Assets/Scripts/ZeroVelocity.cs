using UnityEngine;

public class ZeroVelocity : MonoBehaviour {
	void OnCollisionEnter(Collision other)
	{
		Rigidbody rb = GameObject.Find(other.gameObject.name).GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
	}
}
