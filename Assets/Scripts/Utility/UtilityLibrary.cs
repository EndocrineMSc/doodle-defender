using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityLibrary
{
    #region 2D Transform Helpers

    public static void RotateTransformToFaceTarget2D(Transform transform, Transform target) {
        var direction = target.position - transform.position;
        var zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }

    #endregion
}
