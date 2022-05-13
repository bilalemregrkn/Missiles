using System;
using UnityEngine;

public class FollowController : MonoBehaviour
{
	[SerializeField] private Transform target;
	private Vector3 _offset;

	private void Start()
	{
		_offset = target.position - transform.position;
	}

	private void FixedUpdate()
	{
		var position = -_offset + target.position;
		var currentPosition = Vector3.Lerp(transform.position, position, .5f);
		currentPosition.z = transform.position.z;

		transform.position = currentPosition;
	}
}