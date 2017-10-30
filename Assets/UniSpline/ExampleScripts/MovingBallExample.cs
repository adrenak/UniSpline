using UnityEngine;
using System.Collections;

public class MovingBall : MonoBehaviour {
    [SerializeField]
    BezierBehaviour bezierBehaviour;

    float curvePosition;

    void Update() {
        transform.position = bezierBehaviour.segment.GetPointOnCurve(Time.time % 1F);
    }
}
