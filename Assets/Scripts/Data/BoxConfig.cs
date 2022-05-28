using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box Config", menuName = "SO/New Box Config")]
public class BoxConfig : ScriptableObject
{
    public List<BoxData> boxes;
    public Box boxPrefab;    
}