using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudController : MonoBehaviour
{
	[SerializeField] private float maxDistance;
	[SerializeField] private Vector2 newDistance;
	[SerializeField] private Vector2 rangeScale;

	private void Start()
	{
		UpdateDisplay();
	}

	private void LateUpdate()
	{
		var distance = Vector3.Distance(PlayerController.Instance.transform.position, transform.position);
		if (distance > maxDistance)
		{
			UpdateDisplay();
		}
	}

	private void UpdateDisplay()
	{
		transform.localScale = Vector3.one * Random.Range(rangeScale.x, rangeScale.y);

		var extra = (Vector3)(Random.insideUnitCircle.normalized * Random.Range(newDistance.x, newDistance.y));
		transform.position = PlayerController.Instance.transform.position + extra;
	}
}