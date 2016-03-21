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

	[SerializeField] GameObject		_prefab;

	FloorElement[,]					_floorElements;

	public const int 				length = 100; //ширина поля
	const int 						_firstBusyPercent = 10; //% занятых клеток
}
