using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System;
using Domain.Movement;
using Domain.Movement.JumpController;
using Domain.Movement.Counters;
using UnityEngine.TestTools;
using System.Collections;

public class LongJumpTests
{
    private LongJump CreateLongJump()
    {
        var holder = new GameObject();
        return holder.AddComponent<LongJump>();
    }

    [Test]
    public void Initialization_InitializeWithNullReferences_ThrowException()
    {
        var longJump = CreateLongJump();

        Assert.Throws<NullReferenceException>(() => longJump.Initialize(null, null, null));
    }

    [UnityTest]
    public IEnumerator BaseJump_CharacterIsGrounded_JumpsCountDontChange()
    {
        
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        
        var count = 1;
        
        
        longJump.Initialize(characterMock, counterMock, timerMock);
        counterMock.When(x => x.Reset()).Do( x => count--);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();

        yield return null;

        Assert.AreEqual( 0, count);
    }

    [Test]
    public void BaseJump_CharacterIsntGroundedAndJumpCountMoreThan0_CharacterTurnBack()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();

        longJump.Initialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(false);
        counterMock.Current.Returns(1);
        longJump.BaseJump();

        characterMock.Received().TurnBack();
    }

    [Test]
    public void BaseJump_CharacterIsntGroundedAndJumpCountMoreThan0_DecrementCountOfJumps()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var jumpsCount = 1;

        longJump.Initialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(false);
        counterMock.Current.Returns(1);
        counterMock.When(x => x.Decrement()).Do( x => jumpsCount--);
        longJump.BaseJump();

        Assert.AreEqual(0, jumpsCount);
    }

    [Test]
    public void AdditinalJump_WhenJumpContinueAndJumpDurationMoreThan0_TimerSubstracts()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerValue = 1f;

        longJump.Initialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();
        timerMock.Current.Returns(1);
        timerMock.When(x => x.Substract(Arg.Any<float>())).Do(x => timerValue -= 1f);
        longJump.AdditionalJump();

        Assert.AreEqual(0f, timerValue);
    }

    [Test]
    public void AdditinalJump_WhenJumpContinueAndJumpDurationIsEqual0_TimerReset()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerCurrentValue = 0f;
        var timerStartValue = 1f;

        longJump.Initialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();
        timerMock.Current.Returns(0);
        timerMock.When(x => x.Reset()).Do( x => timerCurrentValue = timerStartValue);
        longJump.AdditionalJump();

        Assert.AreEqual(timerStartValue, timerCurrentValue);
    }

    [Test]
    public void AdditionalJump_WhenJumpDontContinue_TimerDontInvokeSubstract()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerValue = 1f;

        longJump.Initialize(characterMock, counterMock, timerMock);
        timerMock.When(x => x.Substract(Arg.Any<float>())).Do(x => timerValue -= 1f);
        longJump.AdditionalJump();

        Assert.AreEqual(1f, timerValue);
    }
}
