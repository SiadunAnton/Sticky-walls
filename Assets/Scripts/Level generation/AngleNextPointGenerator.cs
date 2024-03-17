using UnityEngine;
using Random = UnityEngine.Random;

public class AngleNextPointGenerator : INextPointGenerator
{
    private float _angle;

    public AngleNextPointGenerator(float angle)
    {
        _angle = angle;
    }

    public Vector3 Get(Vector3 start, float distance)
    {
        var angle = Random.Range(-_angle, _angle);
        var quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        return start + quaternion * Vector3.up * distance;
    }
}
