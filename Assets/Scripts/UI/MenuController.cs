using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
	public void Show(Building buid)
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
		_floorController.CanPosition(_build.indexX, _build.indexY, _build.size, true, true);

		GameObject.Destroy(_build.gameObject);
		Hide();
	}

	Building							_build;
	[SerializeField] MenuInfo			_info;
	[SerializeField] FloorController	_floorController;
}
