using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
	void Show(Building buid)
	{
		gameObject.SetActive(true);
		_build = buid;
	}

	public void Info()
	{
		_info.Show(_build.info);
		Hide();
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Destroy()
	{
		for (int i=0; i<_build.firstIndexBusy.Length; i++)
		{
			_floor.SetFreeOrBusy(true, _build.firstIndexBusy[i], _build.secondIndexBusy[i]);
		}
		GameObject.Destroy(_build.gameObject);
		Hide();
	}

	Building							_build;
	[SerializeField] MenuInfo			_info;
	[SerializeField] FloorController	_floor;
}
