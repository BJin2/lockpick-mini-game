using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCylinder : MonoBehaviour
{
	public Transform top;
	public Transform bottom;
	public float distance { get; private set; }

	public void CalculateDistance()
	{
		distance = Mathf.Abs(top.position.y - bottom.position.y);
	}
}
