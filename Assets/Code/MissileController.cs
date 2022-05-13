using System;
using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{
	[SerializeField] private new Rigidbody2D rigidbody2D;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotateSpeed;
	[Range(1, 20)] [SerializeField] private float lifeTime;
	[SerializeField] private SpriteRenderer renderer;
	[SerializeField] private Collider2D collider2D;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(lifeTime);
		Kill();
	}

	private void FixedUpdate()
	{
		var direction = PlayerController.Instance.transform.position - transform.position;
		direction = direction.normalized;

		var rotateAmount = Vector3.Cross(direction, transform.up).z;

		rigidbody2D.velocity = transform.up * (moveSpeed * Time.deltaTime);
		rigidbody2D.angularVelocity = -rotateAmount * (rotateSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Missile"))
		{
			Kill();
		}
	}

	private void Kill()
	{
		renderer.enabled = false;
		collider2D.enabled = false;
		moveSpeed = 0;
	}
}