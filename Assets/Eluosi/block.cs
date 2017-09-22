using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

    public string[] blockcube;
    private bool[,] blockMatrix;
    private int Size;
    private float childSize;
    // Use this for initialization
    void Update() {
        Size = blockcube.Length;
        childSize = (Size - 1) * 0.5f;
        blockMatrix = new bool[Size, Size];
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (blockcube[y][x] == '1')
                {

                    blockMatrix[y, x] = true;
                    var cube = (Transform)Instantiate(Manager.manager.cube, new Vector3(x - childSize, childSize - y, 0), Quaternion.identity);
                    
                    cube.parent = transform;

                }
            }
        }
    }

   
}
