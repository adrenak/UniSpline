using UnityEngine;

[System.Serializable]
public class BezierCurve {
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 startTan;
    public Vector3 endTan;

    public Vector3[] GetRoughCurve(int samples) {
        samples = Mathf.Max(1, samples);
        var curvePoints = new Vector3[samples + 1];

        // B(t) = 
        // (1-t)^3 * sp + 
        // 3 * (1-t)^2 * t * st +
        // 3 * (1-t) * t^2 * et + 
        // t ^3 * ep
        // Where
        // sp = start position
        // ep = end position
        // st = start tangent
        // et = end tangent
        // t = [0,1]

        for (int i = 0; i <= samples; i++) {
            // calculate the granularity of the curve
            float t = i / (float)samples;

            float omt = 1.0f - t; // One minus t = omt

            curvePoints[i] = GetPointOnCurve(t);
        }
        return curvePoints;
    }

    public Vector3 GetPointOnCurve(float t) {
        float omt = 1F - t;
        return (omt * omt * omt) * startPos +
                (3 * omt * omt * t) * startTan +
                (3 * omt * t * t) * endTan +
                (t * t * t) * endPos;
    }
}
