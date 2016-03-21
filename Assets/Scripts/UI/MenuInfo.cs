using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuInfo : MonoBehaviour 
{
	public void Show(string info)
	{
		gameObject.SetActive(true);
		_text.text = info;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	[SerializeField] Text _text;
}
