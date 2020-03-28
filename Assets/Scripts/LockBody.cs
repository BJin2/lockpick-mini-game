using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBody : MonoBehaviour
{
	public enum Difficulty
	{
		Hard,
		Hell
	}
	public Transform top;
	public Transform bottom;
	public float length { get; private set; }

	public Difficulty difficulty;

	private bool open = false;

	public Pin[] pins;
	public KeyCylinder keyCylinder;
	public Lockpick lockpick;

	public int pinIndex { get; private set; }

	private void Awake()
	{
		lockpick.SetLockBody(this);
		CalculateLength();
		keyCylinder.CalculateLength();
		foreach (Pin p in pins)
		{
			p.SetOwner(this);
			p.Setup();
		}
	}

	private void Update()
	{
		if (open)
			return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (pins[pinIndex].Stuck())
			{
				pinIndex++;
				if (pinIndex == pins.Length)
				{
					pinIndex = 0;
					keyCylinder.Open();
					open = true;
					//TODO show clear
				}
			}
			else
			{
				keyCylinder.Shake();
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			pins[pinIndex].Push();
		}
	}

	private void CalculateLength()
	{
		length = Mathf.Abs(top.position.y - bottom.position.y);
	}

	public void ReleaseAll()
	{
		foreach (Pin p in pins)
		{
			p.Release(true);
		}
		pinIndex = 0;
	}
}
