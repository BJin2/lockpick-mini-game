using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
	private LockBody owner;
	public Transform top;
	public Transform bottom;

	public float distance { get; private set; }

	public bool stuck { get; private set; }

	private void CalculateDistance()
	{
		distance = Mathf.Abs(top.position.y - bottom.position.y);
	}
	private void RandomScale()
	{
	}
	private void RandomPosition()
	{

	}
	public void Stuck()
	{
		stuck = true;
	}
	public void Setup()
	{
		CalculateDistance();
		RandomScale();
		RandomPosition();
	}
}
