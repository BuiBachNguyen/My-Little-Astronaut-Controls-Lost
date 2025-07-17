using System;
using UnityEngine;

public class Constraint
{
    public const float CD_JUMP = 0.5f;
    public const float MAX_JUMP_TIME = .5f;
    public const float MAX_SPEED = 5.0f;
    public static float MAX_FALLING = 5f;
    public static float MAX_JUMP_SPEED = 5f;
}

public class Tag
{
    public const string Ground = "Ground";
    public const string Ladder = "Ladder";
}
