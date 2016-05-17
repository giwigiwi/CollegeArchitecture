using UnityEngine;
using System.Collections;

public class PointPath : MonoBehaviour {

    public GameObject[] pathLine;
    public bool monitoring = false;

    public void Update()
    {
        if (monitoring)
        {
            for (int i = 0; i < pathLine.Length; i++)
                Debug.DrawLine(transform.position, pathLine[i].transform.position);
        }


    }


}
