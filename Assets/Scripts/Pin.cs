using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
	private LockBody owner;
	public float speed = 1;
	public Transform top;
	public Transform bottom;

	private Vector3 initialPosition;//position where it started
	private Vector3 snapPosition;//goal position. will snap to this position when stuck
	private float positionLimit;//distance it can go(upward only)
	private float snapRange;//offset from goal position that allows pin to snap(up and down) depend on difficulty and player skill

	private Color initialColor;//color it started with

	public float length { get; private set; }

	public bool stuck { get; private set; }

	private void Update()
	{
		if (stuck)
			return;

		if(transform.position.y > initialPosition.y)
		{
			transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
			if (transform.position.y <= initialPosition.y)
				Release(false);
		}
		float distance = Mathf.Abs(transform.position.y - snapPosition.y);
		ChangeColor(distance <= snapRange);
	}

	private void CalculateLength()
	{
		length = Mathf.Abs(top.position.y - bottom.position.y);
	}
	private void RandomScale()
	{
		float scale_max = owner.length / length;
		float scale_min = owner.keyCylinder.length / length;
		float scale = Random.Range(scale_min, scale_max);
		transform.localScale = new Vector3(1, scale, 1);
		length *= scale;
	}
	private void RandomPosition()
	{
		float y_max = owner.bottom.position.y + length;
		float y_min = owner.bottom.position.y;
		float y = Random.Range(y_min, y_max);
		transform.position = new Vector3(transform.position.x, y , transform.position.z);
	}
	private void ChangeColor(bool available)
	{
		if (available)
		{
			transform.Find("Pin").GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		}
		else
		{
			transform.Find("Pin").GetComponent<Renderer>().material.color = initialColor;
		}
	}
	public void Push()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
		if (transform.position.y > positionLimit)
		{
			transform.position = new Vector3(transform.position.x, positionLimit, transform.position.z);
		}
	}
	public void Release(bool playSound)
	{
		stuck = false;
		transform.position = initialPosition;
		if (playSound)
		{
			//TODO tick or beep sound
		}
	}
	public bool Stuck()
	{
		float distance = Mathf.Abs(transform.position.y - snapPosition.y);
		if (distance <= snapRange)
		{
			stuck = true;
			//TODO click sound
			transform.position = snapPosition;
		}
		else
		{
			//TODO Release all depend on difficulty
			Release(true);
		}
		return stuck;
	}
	public void SetOwner(LockBody _owner)
	{
		owner = _owner;
	}
	public void Setup()
	{
		CalculateLength();
		RandomScale();
		RandomPosition();

		initialPosition = transform.position;
		positionLimit = owner.top.position.y;
		snapPosition = new Vector3(transform.position.x, owner.bottom.position.y + length, transform.position.z);
		//TODO percentage based on difficulty
		snapRange = (transform.localScale.y * length) * 0.1f;//10% of length 

		initialColor = transform.Find("Pin").GetComponent<Renderer>().material.color;
	}
}
