using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBody : MonoBehaviour
{
	public Transform top;
	public Transform bottom;
	public float distance { get; private set; }

	public Pin[] pins;
	public KeyCylinder keyCylinder;

	private void Awake()
	{
		CalculateDistance();
		keyCylinder.CalculateDistance();
		foreach (Pin p in pins)
		{
			p.Setup();
		}
	}

	private void CalculateDistance()
	{
		distance = Mathf.Abs(top.position.y - bottom.position.y);
	}
}
