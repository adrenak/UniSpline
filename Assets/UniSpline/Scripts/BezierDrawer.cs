using UnityEngine;

namespace UniSpline {
    public class BezierDrawer : MonoBehaviour {
        [SerializeField]
        Transform startPos;

        [SerializeField]
        Transform endPos;

        [SerializeField]
        Transform startTan;

        [SerializeField]
        Transform endTan;

        [SerializeField]
        int renderSamples = 100;

        [SerializeField]
        bool debug;
    
        public Bezier segment;
    
        private void OnDrawGizmos() {
            if (segment == null)
                return;

            segment.startPos = startPos.position;
            segment.endPos = endPos.position;
            segment.startTan = startTan.position;
            segment.endTan = endTan.position;

            Gizmos.color = Color.green;
            var points = segment.GetCurvePoints(renderSamples);
            for(int i = 0; i < points.Length; i++) {
                if (i > 0) 
                    Gizmos.DrawLine(points[i - 1], points[i]);
            }

            if (debug)
                DebugSegment();
        }

        void DebugSegment() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(segment.startPos, segment.startTan);
            Gizmos.DrawLine(segment.startTan, segment.endTan);
            Gizmos.DrawLine(segment.endTan, segment.endPos);
        }
    }
}
