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

	public void SetBusy(int x, int y)
	{
		if (firstIndexBusy == null || secondIndexBusy == null)
		{
			firstIndexBusy = new int[size * size];
			secondIndexBusy = new int[size * size];

			firstIndexBusy[0] = x;
			secondIndexBusy[0] = y;

			for (int i=1; i<size * size; i++)
			{
				firstIndexBusy[i] = -1;
				secondIndexBusy[i] = -1;
			}
		}
		else
		{
			for (int i=0; i<size * size; i++)
			{
				if (firstIndexBusy[i] < 0 || secondIndexBusy[i] < 0)
				{
					firstIndexBusy[i] = x;
					secondIndexBusy[i] = y;
					break;
				}
			}
		}

	}

	public int		size;
	[System.NonSerialized]
	public int[]	firstIndexBusy;
	[System.NonSerialized]
	public int[]	secondIndexBusy;
}
