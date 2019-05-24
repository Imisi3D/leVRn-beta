using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationTrigger", menuName = "Guide/AnimationTrigger")]
public class AnimationTriggers : ScriptableObject
{
    public bool WaveBegun{ get; set; } = false;
    public bool WaveEnded{ get; set; } = false;
    public bool PowerOnEnded{ get; set; } = false;
}
