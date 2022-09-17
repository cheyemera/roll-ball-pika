using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
// needs to make pickup object spin 
{

    // Update is called once per frame
    void Update()
    {
        //need to rotate gameobject's transform
        // either translate or rotate & deltatime ensures things so smoothly
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
