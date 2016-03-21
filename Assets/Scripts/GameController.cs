using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public void Create(GameObject prefab)//добавить новое здание
	{
		Transform go = GameObject.Instantiate(prefab.transform);
		go.SetParent(_parentBuilds);
		_newBuilding = go.gameObject.GetComponent<Building>();
	}

	public void Clear() //удалить объект, если таковой имеется в незакрепленном состоянии
	{
		if (_newBuilding != null)
		{
			GameObject.Destroy(_newBuilding.gameObject);
			_newBuilding = null;
		}
	}

	public void OnClick() //попытка закрепить здание или вызвать у уже имеющегося здания информацию
	{

	}

	void Update()
	{

	}

	[SerializeField] Transform		_parentBuilds; //родитель всех зданий
	[SerializeField] GameObject		_camera;
	Building 						_newBuilding; //новое здание, которое ожидает постановки
}
