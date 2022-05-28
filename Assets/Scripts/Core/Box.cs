using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    BoxData boxData;
    [SerializeField] MeshRenderer renderer;

    public void Init(BoxData boxData) {
        SetData(boxData);
    }

    void SetData(BoxData boxData) {
        this.boxData = boxData;
        transform.position = boxData.boxPosition;        
        SetColorData(boxData.defaultColor);
        SetScale();        
    }

    public BoxData GetData()
    {        
        if (boxData != null) {
            return boxData;
        }
        return null;        
    }

    public void SetColorData(ColorData colorData)
    {        
        renderer.material.color = colorData.color;
    }

    public void SetScale()
    {
        if (boxData.boxType == BoxType.Small) {
            transform.localScale = Vector3.one * 2;
        }
        else if (boxData.boxType == BoxType.Medium)
        {
            transform.localScale = Vector3.one * 3;
        }
        else if (boxData.boxType == BoxType.Large)
        {
            transform.localScale = Vector3.one * 4;
        }
    }

}
