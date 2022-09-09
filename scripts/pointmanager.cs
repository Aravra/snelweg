using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class pointmanager : MonoBehaviour
{
    public bool goforward;
    public bool startmove;

    int nextspline = 10;
    public Vector3 pointlocation;
    public GameObject currentpoint;
    bool checksetup;
    GameObject pointmoverprefab;
    BezierSpline[] splines;
    public int currentforward;
    public int currentbackward;
    GameObject pointsystem;

    void Start()
    {
        checksetup = false;
        pointmoverprefab = GameObject.Find("pointsystem").GetComponent<pointsystem>().pointmoverprefab;
        splines = GameObject.Find("pointsystem").GetComponent<pointsystem>().allsplines;
        pointsystem = GameObject.Find("pointsystem");
        currentforward = pointsystem.GetComponent<pointsystem>().currentforward;
        currentbackward = pointsystem.GetComponent<pointsystem>().currentbackward;

    }
    public void setup()
    {
        GameObject pointmoverinitiated = Instantiate(pointmoverprefab);
        currentpoint = pointmoverinitiated;
        pointmoverinitiated.transform.parent = this.transform;
        var pointmoverscript = pointmoverinitiated.GetComponent<pointmover>();
        if (goforward)
        {
            pointmoverscript.spline = splines[0];
            pointmoverscript.m_normalizedT = 0f;
            nextspline = 1;
        }
        else
        {
            int splinelength = splines.Length;
            splinelength = splinelength - 1;
            nextspline = splinelength -1;
            pointmoverscript.spline = splines[splinelength];
            pointmoverscript.m_normalizedT = 1f;
        }
        pointmoverscript.speed = 100 / 3.6f;
        pointmoverscript.rotationLerpModifier = 0f;
        pointmoverscript.startmove = true;
        checksetup = true;
    }

    public void OnDestroy()
    {
        
    }
    
    public void next()
    {
        int splinelength = splines.Length;
        if (nextspline == -1 && goforward == false)
        {
            GameObject.Find("pointsystem").GetComponent<pointsystem>().disabledbackward += 1;
            Destroy(this.gameObject);
        }
        else if (splinelength == nextspline && goforward == true)
        {
            GameObject.Find("pointsystem").GetComponent<pointsystem>().disabledforward += 1;
            Destroy(this.gameObject);
        }
        else
        {
            GameObject pointmoverinitiated = Instantiate(pointmoverprefab);
            currentpoint = pointmoverinitiated;
            pointmoverinitiated.transform.parent = this.transform;
            var pointmoverscript = pointmoverinitiated.GetComponent<pointmover>();
            if (goforward)
            {
                pointmoverscript.spline = splines[nextspline];
                pointmoverscript.m_normalizedT = 0f;
                nextspline = nextspline + 1;
            }
            else
            {
                pointmoverscript.spline = splines[nextspline];
                nextspline = nextspline - 1;
                pointmoverscript.m_normalizedT = 1f;
            }
            pointmoverscript.speed = 100 / 3.6f;
            pointmoverscript.rotationLerpModifier = 0f;
            pointmoverscript.startmove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startmove)
        {
            setup();
            startmove = false;

        }
        if (checksetup)
        {
            pointlocation = currentpoint.transform.position;
            int check = 0;
            if (goforward)
            {
                if (check < 1)
                {
                    pointsystem.GetComponent<pointsystem>().forwardpoints.Add(pointlocation);
                }
                pointsystem.GetComponent<pointsystem>().forwardpoints.Insert(currentforward, pointlocation);
                pointsystem.GetComponent<pointsystem>().Counter++;
            }
            else
            {
                if (check < 1)
                {
                    pointsystem.GetComponent<pointsystem>().backwardpoints.Add(pointlocation);
                }
                pointsystem.GetComponent<pointsystem>().backwardpoints.Insert(currentbackward, pointlocation);
            }
            check++;
        }
    }
}
