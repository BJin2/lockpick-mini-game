using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : MonoBehaviour
{
	private LockBody lockBody;
	private int pinIndex;

	private void MoveToPinEnd()
	{
		transform.position = lockBody.pins[pinIndex].bottom.position;
	}
}
