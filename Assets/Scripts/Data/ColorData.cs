using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color Data", menuName = "SO/New Color Data")]
public class ColorData : ScriptableObject
{    
    public Color color = new Color32(0, 0, 0, 255);    
}
