using UnityEngine;
using System.Collections;

public class PointPath : MonoBehaviour {

    public GameObject[] pathLine;
    public bool monitoring = false;
    public GameObject text;
    private TextMesh textM;
    private GameObject gmText;

    public void Start()
    {
        gmText = (GameObject)Instantiate(text, transform.position, Quaternion.identity);
        textM = gmText.GetComponent<TextMesh>();
    }

    public void Update()
    {
        if (monitoring)
        {

            for (int i = 0; i < pathLine.Length; i++)
                Debug.DrawLine(transform.position, pathLine[i].transform.position);
            textM.text = gameObject.name;
        }


        


    }


}
