using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RoundAndRound : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.up, 100.0f * Time.deltaTime);
        this.transform.Rotate(Vector3.forward, 100.0f * Time.deltaTime);
    }
}
