using UnityEngine;

namespace Domain.Movement.Services
{
    public class GroundCheckService
    {
        public static bool IsObjectGrounded(Transform aTransform, float radius)
        {
            return Physics2D.OverlapArea(aTransform.position + new Vector3(-radius, radius - 0.01f, 0f),
                                                aTransform.position + new Vector3(radius, -radius, 0f),
                                                                 LayerMask.GetMask("Ground"));
        }
    }
}