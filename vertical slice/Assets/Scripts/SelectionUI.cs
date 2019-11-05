using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    private MapCube turrent;

    public void SetTarget(MapCube _turrent)
    {
        turrent = _turrent;

        transform.position = turrent.GetBuildPosition();
    }
}
