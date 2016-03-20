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

	bool 							_isFree = true;

	[SerializeField] MeshRenderer 	_render;
	[SerializeField] Material		_freeMaterial;
	[SerializeField] Material		_busyMaterial;
}
