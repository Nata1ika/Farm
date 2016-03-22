using UnityEngine;
using System.Collections;

public class FloorElement : MonoBehaviour
{
	public const int length = 10;

	public bool isFree
	{
		get
		{
			return _isFree;
		}
		set
		{
			_isFree = value;
			_render.material = value ? _freeMaterial : _busyMaterial;
		}
	}

	[System.NonSerialized] public int 	indexX; //координаты в массиве всех элементов
	[System.NonSerialized] public int 	indexY;

	bool 								_isFree = true;

	[SerializeField] MeshRenderer 		_render;
	[SerializeField] Material			_freeMaterial;
	[SerializeField] Material			_busyMaterial;
}
