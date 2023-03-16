using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatform : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("AutomaticPlatform"))
        {
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("AutomaticPlatform"))
        {
            this.transform.parent = null;
        }
    }
}
