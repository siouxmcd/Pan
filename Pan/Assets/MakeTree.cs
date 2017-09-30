using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTree : MonoBehaviour {
    public int time = 2;
    public double minDistance = 0.1;
    public bool autoCalculateOrientation = true;

    private bool invertFaces = false;
    private Mesh srcMesh;
    private MeshExtrusion.Edge[] precomputedEdges;
    class ExtrudedTrunk
    {
        Vector3 point;
        Matrix4x4 matrix;
        float time;
    }

	// Use this for initialization
	void Start () {
        srcMesh = GetComponent<MeshFilter>().sharedMesh;
        precomputedEdges = MeshExtrusion.BuildManifoldEdges(srcMesh);
	}
	
	// Update is called once per frame
	void Update () {
         
	}
}
