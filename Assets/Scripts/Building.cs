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

	public int								size;
	[System.NonSerialized] public int 		indexX;
	[System.NonSerialized] public int		indexY;
}
