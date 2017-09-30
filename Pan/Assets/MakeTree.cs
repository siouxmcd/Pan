using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MakeTree : MonoBehaviour {
    public int time = 2;
    public double minDistance = 0.1;
    public bool autoCalculateOrientation = true;

    private bool invertFaces = false;
    private Mesh srcMesh;
    private MeshExtrusion.Edge[] precomputedEdges;
    //private ArrayList sections = new ArrayList();
    //private object[] sections = new object[1];
    //List<object> sections = new List<object>();
    List<ExtrudedTrunk> sections = new List<ExtrudedTrunk>();
    class ExtrudedTrunk
    {
        public Vector3 point;
        public Matrix4x4 matrix;
        public float time;
    }

	// Use this for initialization
	void Start () {
        srcMesh = GetComponent<MeshFilter>().sharedMesh;
        precomputedEdges = MeshExtrusion.BuildManifoldEdges(srcMesh);
	}

	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        float now = Time.time;

        if (sections.Count == 0 || (sections[0].point - pos).sqrMagnitude > minDistance * minDistance)
        {
            ExtrudedTrunk section = new ExtrudedTrunk();
            section.point = pos;
            section.matrix = transform.localToWorldMatrix;
            section.time = now;
            sections.Insert(0, section);
        }

        if (sections.Count < 2)
            return;

        Matrix4x4 worldToLocal = transform.worldToLocalMatrix;
        Matrix4x4[] finalSections = new Matrix4x4[sections.Count];
        Quaternion previousRotation;

        int i;
        for (i=0; i < sections.Count; i++)
        {
            if (autoCalculateOrientation)
            {
                if (i == 0)
                {
                    Vector3 direction = sections[0].point - sections[1].point;
                    Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
                    previousRotation = rot;
                    finalSections[i] = worldToLocal * Matrix4x4.TRS(pos, rot, Vector3.one);
                }
                else if (i != sections.Count - 1)
                {
                    Vector3 direction = sections[0].point - sections[1].point;
                    Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
                    previousRotation = rot;
                    finalSections[i] = worldToLocal * Matrix4x4.TRS(pos, rot, Vector3.one);
                    if (Quaternion.Angle(previousRotation, rot) > 20)
                        rot = Quaternion.Slerp(previousRotation, rot, 0.5f);  
                }
                else
                {
                    finalSections[i] = finalSections[i - 1];
                }
            }
            else
            {
                if(i == 0)
                {
                    finalSections[i] = Matrix4x4.identity;
                }
                else
                {
                    finalSections[i] = worldToLocal * sections[i].matrix;
                }
            }
        }
        MeshExtrusion.ExtrudeMesh(srcMesh, GetComponent<MeshFilter>().mesh, finalSections, precomputedEdges, invertFaces);
	}
}
