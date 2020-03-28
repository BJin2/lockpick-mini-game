using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCylinder : MonoBehaviour
{
	public Transform top;
	public Transform bottom;
	public float length { get; private set; }
	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void CalculateLength()
	{
		length = Mathf.Abs(top.position.y - bottom.position.y);
	}
	public void Shake()
	{
		anim.Play("Shake", 0, 0);
	}
	public void Open()
	{
		anim.Play("Open");
	}
}
