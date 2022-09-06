using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
