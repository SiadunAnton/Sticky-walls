using UnityEngine;

public interface INextPointGenerator 
{
    public Vector3 Get(Vector3 start, float distance);
}
