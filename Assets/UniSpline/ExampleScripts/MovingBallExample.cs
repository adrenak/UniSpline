using UnityEngine;
using UniSpline;

public class MovingBallExample : MonoBehaviour {
    [SerializeField]
    BezierDrawer bezierBehaviour;

    float curvePosition;

    void Update() {
        transform.position = bezierBehaviour.segment.GetPointOnCurve(Time.time % 1F);
    }
}
