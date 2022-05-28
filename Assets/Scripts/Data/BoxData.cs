using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box Data", menuName = "SO/New Box Data")]
public class BoxData : ScriptableObject
{
    public int boxID;
    public Vector3 boxPosition;
    public BoxType boxType;    
    public ColorData defaultColor;
    public ColorData nearestColor;
    public ColorData secondNearestColor;
}

public enum BoxType {
    None,
    Small,
    Medium,
    Large
}
