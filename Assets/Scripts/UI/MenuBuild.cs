using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuBuild : MonoBehaviour
{
	[System.Serializable]
	public class Conformity
	{
		public Button		button;
		public GameObject	prefab;
	}

	public void Show()
	{
		_menu.SetActive(true);
		_controller.Clear();
	}

	public void Hide()
	{
		_menu.SetActive(false);
	}

	void Start()
	{
		for (int i=0; i<_buttons.Length; i++)
		{
			int k = i;
			_buttons[i].button.onClick.AddListener(()=>{OnClick(_buttons[k].prefab);});
		}
	}

	void OnDestroy()
	{
		for (int i=0; i<_buttons.Length; i++)
		{
			_buttons[i].button.onClick.RemoveAllListeners();
		}
	}

	void OnClick(GameObject prefab)
	{
		Hide();
		_controller.Create(prefab);
	}

	[SerializeField] GameObject 	_menu;
	[SerializeField] Conformity[]	_buttons;
	[SerializeField] GameController _controller;
}
