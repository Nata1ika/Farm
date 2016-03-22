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

	public void OnClick()
	{
		if (_newBuilding != null && _newBuilding.isCorrectPosition)
		{
			_floorController.CanPosition(_newBuilding.indexX, _newBuilding.indexY, _newBuilding.size, true, false);
			_newBuilding = null; //постановка объекта завершена
		}
	}

	void Update() //попытка закрепить здание или вызвать у уже имеющегося здания информацию
	{
		if (_newBuilding != null)
		{
			// создаем луч на основе позиции мыши и компонента камеры,принадлежащей текущему объекту
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit; //будет содержать результат "бросания" луча в пространство сцены
			if (! Physics.Raycast(ray, out hit)) // Если не попали в какой-либо объект
			{
				return;
			}
			GameObject go = hit.collider.gameObject; //выбранный объект
			FloorElement floorElement = go.GetComponent<FloorElement>();
			//выбранный объект оказался не плиткой пола или часть клеток уже заняты
			if (floorElement == null) 
			{
				return;
			}
			_newBuilding.indexX = floorElement.indexX;
			_newBuilding.indexY = floorElement.indexY;

			//ставьм строение в нужное место
			Vector3 delta = new Vector3(0, FloorElement.length / 2, 0);

			if (_newBuilding.size % 2 == 0) //сдвиг в из-за несимметричности четного коичества кубов
			{
				delta += new Vector3(FloorElement.length / 2, 0, FloorElement.length / 2);
			}
			_newBuilding.gameObject.transform.position = floorElement.gameObject.transform.position + delta;

			_newBuilding.isCorrectPosition = _floorController.CanPosition(floorElement.indexX, floorElement.indexY, _newBuilding.size, false, false);
		}
	}

	[SerializeField] Transform			_parentBuilds; //родитель всех зданий
	[SerializeField] Camera				_camera;
	[SerializeField] FloorController	_floorController;

	Building 							_newBuilding; //новое здание, которое ожидает постановки
}
