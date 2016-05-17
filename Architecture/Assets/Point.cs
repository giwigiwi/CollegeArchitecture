using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Point : MonoBehaviour {
    public GameObject[] point;
    public GameObject positPoint;
    private GameObject tempObject;
    public List<Path> ArrayPath;
    public GameObject target;
    public GameObject scriptPath;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            FindThePath();
	}
    private Vector2 VectorAbs(Vector2 vec)
    {
        Vector2 abs = new Vector2(Mathf.Abs(vec.x),Mathf.Abs(vec.y));
        return abs;
    }



    public void FindThePath()
    {
        Debug.ClearDeveloperConsole();
        Path sPath = Instantiate(scriptPath).GetComponent<Path>();

        sPath.ignoreList.Add(positPoint);
        sPath.pathGameObject.Add(positPoint);
        int index = 0;
        while (positPoint != target)
        {
            GameObject tempGM = MinimumDistance(sPath);
            sPath.ignoreList.Add(tempGM);
            positPoint = tempGM;
            sPath.pathGameObject.Add(positPoint);
            index++;
            if (index > 100)
                break;

        }
        ArrayPath.Add(sPath);
        sPath.ConstructPath();
    }

    private float VectorDistance(Vector2 v1, Vector2 v2)
    {
        float distance;
        float xx = v2.x-v1.x;
        float yy = v2.y-v1.y;
        distance=Mathf.Sqrt((xx*xx)+(yy*yy));

        return distance;
    }


    public GameObject MinimumDistance(Path pathIgnore)
    {
        GameObject gm=null;
        
        float minPosit=1000000;
        for (int i = 0; i < point.Length; i++)
        {
            Debug.Log(i);
            Vector2 point1 = positPoint.transform.position;
            Vector2 point2 = point[i].transform.position;
            if (!pathIgnore.IsIgnore(point[i]))
            {

            float temp = VectorDistance(point1,point2);
            if (minPosit > temp)
            {
                minPosit = temp;

                gm = point[i];
            } 
            }
        }

        Debug.Log(gm + " = " + minPosit);
        return gm;
    }
}
