using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;
	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (.2f, .2f);
		laserLine.SetPosition(0, startPoint.position);
		laserLine.SetPosition(1, endPoint.position);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
