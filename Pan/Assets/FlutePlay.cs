using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlutePlay : MonoBehaviour {

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
}
