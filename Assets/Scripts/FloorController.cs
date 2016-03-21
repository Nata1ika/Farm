using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour 
{
	void Start()
	{
		Create();
	}

	void Create()
	{
		_floorElements = new FloorElement[length, length];

		Transform parent = gameObject.transform;

		for (int i=0; i<length; i++)
		{
			for (int j=0; j<length; j++)
			{
				Transform go = GameObject.Instantiate(_prefab.transform);
				go.SetParent(parent);
				go.position = new Vector3(i * FloorElement.length, 0, j * FloorElement.length);
				_floorElements[i,j] = go.gameObject.GetComponent<FloorElement>();
				if (_floorElements[i,j] != null)
				{
					_floorElements[i,j].isFree = Random.Range(0, 100) >= _firstBusyPercent;
					_floorElements[i,j].indexX = i;
					_floorElements[i,j].indexY = j;
				}
			}
		}
	}

	public void SetFreeOrBusy(bool free, int x, int y)
	{
		if (_floorElements != null && x >= 0 && y >= 0 && x < length && y < length)
		{
			_floorElements[x,y].isFree = free;
		}
	}

	public bool CanPosition(int x, int y, int size, bool changeState, bool isFree) //проверяем возможно ли поставить куб в центральной клетке с указанными индексами и выбранным размером. для четных размеров - клетки предполагаются на 1 больше
	{
		//проверм что не вылезет за границы
		if (0 <= x - size / 2 - size % 2 + 1 && x + size / 2 < length &&
		    0 <= y - size / 2 - size % 2 + 1 && y + size / 2 < length)
		{
			for (int i = x - size / 2 - size % 2 + 1; i < x + size / 2; i++)
			{
				for (int j = y - size / 2 - size % 2 + 1; j < y + size / 2; j++)
				{
					if (changeState)
					{
						_floorElements[i,j].isFree = isFree;
					}
					else if (! _floorElements[i,j].isFree) //если клетка затяна false
					{
						return false;
					}
				}
			}

			if (! changeState)
			{
				return CanPosition(x, y, size, true, isFree);
			}
			else
			{
				return true;
			}
		}
		else //какая-то из клеток куба не влезла
		{
			return false;
		}
	}

	[SerializeField] GameObject		_prefab;

	FloorElement[,]					_floorElements;

	public const int 				length = 100; //ширина поля
	const int 						_firstBusyPercent = 10; //% занятых клеток
}
