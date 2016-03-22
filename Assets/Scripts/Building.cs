using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
	public string info
	{
		get
		{
			return string.Format("{0} x {1}", size, size);
		}
	}

	public bool isCorrectPosition
	{
		get
		{
			return _isCorrectPosition;
		}
		set
		{
			_mesh.material = value ? _mainMaterial : _errorMaterial;
			_isCorrectPosition = value;
		}
	}

	public void ActivateBoxCollider()
	{
		_collider.enabled = true;
	}

	public int								size;
	[System.NonSerialized] public int 		indexX; //индекс плитки, на которм находится объект
	[System.NonSerialized] public int 		indexY;

	bool									_isCorrectPosition = false;

	[SerializeField] BoxCollider			_collider;
	[SerializeField] MeshRenderer			_mesh;
	[SerializeField] Material				_mainMaterial;//основной материал 
	[SerializeField] Material				_errorMaterial;//материал, при котором строение находится на уже занятой клетке
}
