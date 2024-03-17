using NUnit.Framework;
using UnityEngine;
using Domain.Movement;

public class NaturalGravityTests
{
    [Test]
    public void InvokingFunctions_SetLevel_gravityScaleIsEqual()
    {
        var holder = new GameObject();
        var rigidbody = holder.AddComponent<Rigidbody2D>();
        var gravity = holder.AddComponent<NaturalGravity>();
        var level = 0.5f;

        gravity.SetLevel(level);

        Assert.AreEqual(rigidbody.gravityScale, level);
    }

    [Test]
    public void InvokingFunctions_WhenStop_gravityScaleIsEqual0()
    {
        var holder = new GameObject();
        var rigidbody = holder.AddComponent<Rigidbody2D>();
        var gravity = holder.AddComponent<NaturalGravity>();

        gravity.Stop();

        Assert.AreEqual(0f, rigidbody.gravityScale);
    }

    [Test]
    public void InvokingFunctions_WhenRestoreAfterStop_gravityScaleIsTheSame()
    {
        var holder = new GameObject();
        var rigidbody = holder.AddComponent<Rigidbody2D>();
        var gravity = holder.AddComponent<NaturalGravity>();
        var startGravityScale = rigidbody.gravityScale;

        gravity.Stop();
        gravity.Restore();

        Assert.AreEqual( startGravityScale, rigidbody.gravityScale);
    }
}
