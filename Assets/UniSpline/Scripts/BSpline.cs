using UnityEngine;

public class BSpline : MonoBehaviour {
    public int subdivision;

    public Transform[] GetChildrenOrdered() {
        var children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
            children[i] = transform.GetChild(i);
        return children;
    }
}
