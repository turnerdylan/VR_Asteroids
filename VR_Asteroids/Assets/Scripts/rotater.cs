using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 rotation;
    void Start()
    {
        rotation = new Vector3(Random.Range(0, 10),Random.Range(0, 10),Random.Range(0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation);
    }
}
