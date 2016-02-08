using UnityEditor;
using UnityEngine;

/*Stuff inspired by:
http://answers.unity3d.com/questions/782478/unity-46-beta-anchor-snap-to-button-new-ui-system.html
*/

public class uGUITools
{
    [MenuItem("Anias/Anchors to Corners %[")] //adds a menu item in unity editor 
    static void AnchorsToCorners()
    {

        //get rect transform for active (selected) element and its parent
        RectTransform t = Selection.activeTransform as RectTransform;
        RectTransform pt = Selection.activeTransform.parent as RectTransform;
        //if no active elems or has no parent do nothing
        //(elems with no parent can't really anchor to anything!, even though they have rect transform e.g. canvas)
        if (t == null || pt == null) return;
        /*
        Anchors are treated as RECTANGLE described by position of upper right and lower lef anchor (anchorMax, anchorMin)
        anchorMax	The  position in the *parent* RectTransform that the upper right corner is anchored to.
        offsetMax	The offset of the *upper right corner* of the rectangle relative to the *upper right anchor*.
        anchorMin	The  position in the parent RectTransform that the lower left corner is anchored to.
        offsetMin	The offset of the lower left corner of the rectangle relative to the lower left anchor.
        see: http://docs.unity3d.com/ScriptReference/RectTransform.html
        */
        //Calculates new positions
        Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                            t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                            t.anchorMax.y + t.offsetMax.y / pt.rect.height);
        //Sets up new positions
        t.anchorMin = newAnchorsMin;
        t.anchorMax = newAnchorsMax;
        // Clean up - change offsets manually - so that elem won't be RESIZED to fit to the new anchor positions and PLUS old offsets
        // Elements SIZE is (re)calculated based on anchors + offsets! 
        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("Anias/Corners to Anchors %]")]
    static void CornersToAnchors()
    {
        RectTransform t = Selection.activeTransform as RectTransform;

        if (t == null) return;

        //Changing offsets manually magically changes the corners possition and resizes the entire elemet.
        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }
}
