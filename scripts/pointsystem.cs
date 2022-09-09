using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class pointsystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointmoverprefab;
    public GameObject pointmanagerprefab;
    public List<Vector3> forwardpoints = new List<Vector3>();
    public List<Vector3> backwardpoints = new List<Vector3>();
    public BezierSpline[] allsplines;
    public int disabledforward = -1;
    public int currentforward = -1;
    public int disabledbackward = -1;
    public int currentbackward = -1;
    public int Counter = 0;
    void Start()
    {
        StartCoroutine(spawn());    
    }

    IEnumerator spawn()
    {
        bool i = true;
        int j = 0;
        //Time.timeScale = 10;
        while (i)
        {
            j++;
            spawnforward();
            spawnbackward();
            if (j == 100)
            {
                Time.timeScale = 1;
            }
            yield return new WaitForSeconds(2.16f);
        }
    }
    public void spawnforward()
    {
        currentforward++;
        GameObject pointmanagerinitiated = Instantiate(pointmanagerprefab);
        pointmanagerinitiated.transform.parent = this.transform;
        var pointmanagerscript = pointmanagerinitiated.GetComponent<pointmanager>();
        pointmanagerscript.goforward = true;
        pointmanagerscript.startmove = true;
    }
    public void spawnbackward()
    {
        currentbackward++;
        GameObject pointmanagerinitiated2 = Instantiate(pointmanagerprefab);
        pointmanagerinitiated2.transform.parent = this.transform;
        var pointmanagerscript2 = pointmanagerinitiated2.GetComponent<pointmanager>();
        pointmanagerscript2.goforward = false;
        pointmanagerscript2.startmove = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
