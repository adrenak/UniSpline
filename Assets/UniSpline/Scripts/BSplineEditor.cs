using UnityEngine;
using UnityEditor;
using UniSpline;

// Good resource on BSpline calculations here : http://www.math.ucla.edu/~baker/149.1.02w/handouts/dd_splines.pdf
[CustomEditor(typeof(BSpline))]
public class BSplineEditor : Editor {
    private void OnSceneGUI() {
        BSpline bSpline = (BSpline)target;

        var transforms = bSpline.GetChildrenOrdered();
        if (transforms == null || transforms.Length == 1)
            return;

        // Control points
        Vector3[] cp = new Vector3[transforms.Length];
        // Generated control points for smooth spline
        Vector3[] gcp = new Vector3[transforms.Length];

        // Populate control points from children array
        for (int i = 0; i < transforms.Length; i++)
            cp[i] = transforms[i].position;

        // Generate new set of control points
        gcp[0] = cp[0];
        gcp[gcp.Length - 1] = cp[cp.Length - 1];
        for (int i = 1; i < gcp.Length - 1; i++)
            gcp[i] = cp[i - 1] / 6 + (2 * cp[i]) / 3 + cp[i + 1] / 6;

        // Render the spline as separate quadratic bezier spline instances
        for (int i = 1; i < gcp.Length; i++) {
            // Construct a Bezier Spline instance and get its curve points
            var b = new UniSpline.Bezier(
                gcp[i - 1],
                (2 * cp[i - 1] / 3) + (cp[i] / 3),
                gcp[i],
                cp[i - 1] / 3 + (2 * cp[i] / 3)
            );
            var points = b.GetCurvePoints(bSpline.subdivision);

            // Render the lines
            for (int j = 1; j < points.Length; j++) 
                    Handles.DrawLine(points[j - 1], points[j]);
        }
    }
}
