using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlutePlay : MonoBehaviour {
    public GameObject tree;
    public int time = 2;
    public double minDistance = 0.1;
    public bool autoCalculateOrientation = true;

    private Vector3 newPos;
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
    private void Start()
    {
        srcMesh = tree.GetComponent<MeshFilter>().sharedMesh;
        precomputedEdges = MeshExtrusion.BuildManifoldEdges(srcMesh);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "pipe1")
        {
            Debug.Log("found pipe 1");
            
        }
        else if (other.gameObject.tag == "pipe2")
        {
            Debug.Log("found pipe 2");
        }
        else if (other.gameObject.tag == "pipe3")
        {
            Debug.Log("found pipe 3");
        }
        else if (other.gameObject.tag == "pipe4")
        {
            Debug.Log("found pipe 4");
        }
        else if (other.gameObject.tag == "pipe5")
        {
            Debug.Log("found pipe 5");
        }
        else if (other.gameObject.tag == "pipe6")
        {
            Debug.Log("found pipe 6");
        }
        else if (other.gameObject.tag == "pipe7")
        {
            Debug.Log("found pipe 7");
        }
        else if (other.gameObject.tag == "pipe8")
        {
            Debug.Log("found pipe 8");
        }
    }
    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "pipe1")
        {
            Debug.Log("OnTriggerStay");
            MakeGrow();
        }
    }
    void MakeGrow()
    {
        Vector3 pos = tree.transform.position;
        float now = Time.time;

        if (sections.Count == 0 || (sections[0].point - pos).sqrMagnitude > minDistance * minDistance)
        {
            ExtrudedTrunk section = new ExtrudedTrunk();
            section.point = pos;
            section.matrix = tree.transform.localToWorldMatrix;
            section.time = now;
            sections.Insert(0, section);
        }

        if (sections.Count < 2)
            return;

        Matrix4x4 worldToLocal = tree.transform.worldToLocalMatrix;
        Matrix4x4[] finalSections = new Matrix4x4[sections.Count];
        Quaternion previousRotation;
        int i;
        float xp = Random.Range(-0.1f, 0.1f);
        float zp = Random.Range(-0.1f, 0.1f);
        for (i = 0; i < sections.Count; i++)
        {
            //if (autoCalculateOrientation)
            //{
            //    if (i == 0)
            //    {
            //        Vector3 direction = sections[0].point - sections[1].point;
            //        Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
            //        previousRotation = rot;
            //        finalSections[i] = worldToLocal * Matrix4x4.TRS(pos, rot, Vector3.one);
            //    }
            //    else
            //    {
            //        finalSections[i] = finalSections[i - 1];
            //    }
            //}
            //else
            //{
            if (i == 0)
            {
                finalSections[i] = Matrix4x4.identity;
            }
            else
            {
                finalSections[i] = worldToLocal * sections[i].matrix;

            }
            tree.transform.position += new Vector3(xp, 0, zp) * Time.deltaTime / 25;
            //}
        }
        MeshExtrusion.ExtrudeMesh(srcMesh, tree.GetComponent<MeshFilter>().mesh, finalSections, precomputedEdges, invertFaces);

    }
}

