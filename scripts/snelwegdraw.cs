using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BezierSolution;

public class snelwegdraw : MonoBehaviour
{
    public GameObject highwaypieceprefab;
    public BezierSpline highwaycurve;
    public GameObject highwaypieces;
    private Vector3 highwaypiecevector;
    private Vector3 highwaypiecetangent;
    public float highwaypiecemodifier;
    void Start()
    {
        float lengte = highwaycurve.GetLengthApproximately(0, 1);
        //BezierSpline.EvenlySpacedPointsHolder splinepoints = highwaycurve.CalculateEvenlySpacedPoints(100f, 0.001f);
        BezierSpline.EvenlySpacedPointsHolder splinepoints = highwaycurve.CalculateEvenlySpacedPoints(10,3);
        float distance2 = lengte - highwaypiecemodifier;
        for (float i = highwaypiecemodifier; i < distance2; i=i+highwaypiecemodifier)
        {
                float splinetvalue = splinepoints.GetNormalizedTAtDistance(i);
                highwaypiecevector = highwaycurve.GetPoint(splinetvalue);
                highwaypiecetangent = highwaycurve.GetTangent(splinetvalue);
                Quaternion snelwegstukrotation = Quaternion.LookRotation(highwaypiecetangent, Vector3.up);
                var snelwegstuk = Instantiate(highwaypieceprefab, highwaypiecevector, snelwegstukrotation);
                snelwegstuk.transform.parent = highwaypieces.transform;
        }
        


    }
}
