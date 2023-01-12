using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class SettingsSO : ScriptableObject
{
    public bool muted;
    public bool vibrationEnabled;
    public bool ads;
}
