using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class pointmover : MonoBehaviour
{
	public BezierSpline spline;

	public float speed = 5f;
	public float m_normalizedT = 0f;
	public float rotationLerpModifier = 0f;
	public bool startmove = false;
	public pointmanager parent;

    public void Start()
    {
		parent = transform.parent.gameObject.GetComponent<pointmanager>();
	}
	public void onPathCompleted()
	{
		parent.next();
		Destroy(this.gameObject);
	}

	private void Update()
	{
		if (startmove)
		{
			posupdate();
		}
	}

	public void posupdate()
	{
        if (parent.goforward)
        {
			Vector3 targetPos = spline.MoveAlongSpline(ref m_normalizedT, speed * Time.deltaTime);
			transform.position = targetPos;
			BezierSpline.Segment segment = spline.GetSegmentAt(m_normalizedT);
			Quaternion targetRotation;
			targetRotation = Quaternion.LookRotation(segment.GetTangent(), segment.GetNormal());
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationLerpModifier * Time.deltaTime);
		}
        else
        {
			Vector3 targetPos = spline.MoveAlongSpline(ref m_normalizedT, -speed * Time.deltaTime);
			transform.position = targetPos;
			BezierSpline.Segment segment = spline.GetSegmentAt(m_normalizedT);
			Quaternion targetRotation;
			targetRotation = Quaternion.LookRotation(-segment.GetTangent(), segment.GetNormal());
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationLerpModifier * Time.deltaTime);
		}
		if(m_normalizedT>1 || m_normalizedT < 0)
        {
			onPathCompleted();
        }
	}
}

