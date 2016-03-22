using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public void PointerDown()
	{
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
		Vector3 currentPos = Input.mousePosition;
		Vector3 pos = _camera.position;

		if (_countDrag == 1) //двигаем камеру по x и z
		{
			Vector2 delta = _speed * (currentPos - _firstClickPos);
			_camera.position =  new Vector3(Mathf.Clamp(pos.x + delta.y, minX, maxX), pos.y, Mathf.Clamp(pos.z - delta.x, minZ, maxX));
			_firstClickPos = currentPos;
		}
		else //камеру по y двигаем
		{
			float firstLength = (currentPos - _firstClickPos).magnitude; //длина вектора движения первого пальца
			float secondLength = (currentPos - _secondClickPos).magnitude; //второго
			float dist = (_secondClickPos - _firstClickPos).magnitude; //первоначальное расстояние между пальцами
			float deltaPosY;
			if (firstLength < secondLength && dist > secondLength)//сближение пальцев, камера вверх
			{
				deltaPosY = firstLength;
			}
			else if (firstLength > secondLength && dist > firstLength)//сближение пальцев, камера вверх
			{
				deltaPosY = secondLength;
			}
			else if (firstLength < secondLength && dist < secondLength)//пальца отдаляются, камера вниз
			{
				deltaPosY = - firstLength;
			}
			else
			{
				deltaPosY = - secondLength;
			}
			_camera.position = new Vector3(pos.x, Mathf.Clamp(pos.y + deltaPosY, minY, maxY), pos.z);
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
	float							_speed = 0.1f;

	int								_countDrag = 0;
	Vector3							_firstClickPos; //используется для движения камеры влево/вправо вверх/вниз
	Vector3							_secondClickPos; //для изменения масштаба, движение камеры по Y
}
