using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public bool sleep
	{
		get
		{
			return _sleep;
		}
		set
		{
			_sleep = value;
			_countDrag = 0;
		}
	}

	public void PointerDown()
	{
		if (sleep)
		{
			return;
		}

		if (_countDrag == 0) //движение только началось 
		{
			_firstClickPos = Input.mousePosition;
		}
		else if (_countDrag == 1) //если движение уже было начато, то сейчас начинаем второе
		{
			_secondClickPos = Input.mousePosition;
		}

		_countDrag ++;
	}

	public void PointerUp()
	{
		_countDrag --;
		if (_countDrag < 0)
		{
			_countDrag = 0;
		}
	}

	public void Drag()
	{
		if (sleep)
		{
			return;
		}

		if (_countDrag == 1) //двигаем камеру по x и z
		{
			Vector3 pos = _camera.position;
			Vector2 delta = _speed * (Input.mousePosition - _firstClickPos);
			_camera.position =  new Vector3(pos.x + delta.y, pos.y, pos.z - delta.x);
			_firstClickPos = Input.mousePosition;
		}
	}

	public float minX
	{
		get
		{
			return _camera.position.y / 2;
		}
	}

	public float maxX
	{
		get
		{
			return _camera.position.y / 2 + 10 * FloorController.length;
		}
	}
		
	public float maxZ
	{
		get
		{
			return 10 * FloorController.length;
		}
	}

	public const float minY = 10;
	public const float maxY = 150;
	public const float minZ = 0;

	[SerializeField] Transform		_camera;
	float							_speed = 0.2f;

	bool							_sleep = false; //при true камера неподвижна
	int								_countDrag = 0;
	Vector3							_firstClickPos; //используется для движения камеры влево/вправо вверх/вниз
	Vector3							_secondClickPos; //для изменения масштаба, движение камеры по Y
}
