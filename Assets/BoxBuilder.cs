using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBuilder : MonoBehaviour
{
	public MeshFilter prefab;

	void Start()
	{
		for (int x = 0; x < 10; ++x)
		{
			for (int y = 0; y < 10; ++y)
			{
				for (int z = 0; z < 10; ++z)
				{
					Vector3 position = new Vector3(x, y, z);
					CreateBox(position * 2);
				}
			}
		}
	}

	void CreateBox(Vector3 position)
	{
		MeshFilter box = Instantiate(prefab, position, Quaternion.identity);
		
		Vector3[] vertices =
		{
			new Vector3(0, 0, 0),
			new Vector3(1, 0, 0),
			new Vector3(1, 1, 0),
			new Vector3(0, 1, 0),
			new Vector3(0, 1, 1),
			new Vector3(1, 1, 1),
			new Vector3(1, 0, 1),
			new Vector3(0, 0, 1),
		};

		int[] front  = { 0, 2, 1, 0, 3, 2 };
		int[] top    = { 2, 3, 4, 2, 4, 5 };
		int[] right  = { 1, 2, 5, 1, 5, 6 };
		int[] left   = { 0, 7, 4, 0, 4, 3 };
		int[] back   = { 5, 4, 7, 5, 7, 6 };
		int[] bottom = { 0, 6, 7, 0, 1, 6 };
			
		Mesh mesh = new Mesh();
		mesh.Clear();
		mesh.subMeshCount = 6;
		mesh.vertices = vertices;
		mesh.SetTriangles(front,  0);
		mesh.SetTriangles(top,    1);
		mesh.SetTriangles(right,  2);
		mesh.SetTriangles(left,   3);
		mesh.SetTriangles(back,   4);
		mesh.SetTriangles(bottom, 5);
		mesh.Optimize();
		mesh.RecalculateNormals();

		box.mesh = mesh;
	}
}
