using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockUI : MonoBehaviour
{
	public static LockUI instance { get; private set; }

	public RectTransform timer;
	public TextMeshProUGUI progress;
	public TextMeshProUGUI success;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
}
