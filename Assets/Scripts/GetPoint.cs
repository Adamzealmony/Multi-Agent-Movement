using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {

    public static Vector3 goalPos = Vector3.zero;

	void FixedUpdate () {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            goalPos = hit.point;
            goalPos.y = 0;
        }
    }
}
