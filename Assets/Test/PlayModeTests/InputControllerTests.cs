using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using System;
using Domain.Movement.Input; 

public class InputControllerTests
{
    private InputController CreateInput()
    {
        var controllerHolder = new GameObject();
        return controllerHolder.AddComponent<InputController>();
    }
    
    [Test]
    public void Initialization_InitializeWithNullValue_ThrowException()
    {
        IConcreteInputSignature nullSignature = null;
        var controllerHolder = new GameObject();
        var controller = controllerHolder.AddComponent<InputController>();

        Assert.Throws<NullReferenceException>(() => controller.Initialize(nullSignature));
    }
    
    [UnityTest]
    [TestCase(true,true, ExpectedResult = null)]
    [TestCase(false,false, ExpectedResult = null)]
    public IEnumerator EventCalling_WhenPressStarted_CallOnTapEvent (bool pressed, bool eventCall)
    {
        var inputSignatureMock = Substitute.For<IConcreteInputSignature>();
   
        var controller = CreateInput();
        
        bool wasCalled = false;

        controller.Initialize(inputSignatureMock);
        inputSignatureMock.IsPressStarted().Returns(pressed);
        controller.OnTap += () => { wasCalled = true; };

        yield return null;

        Assert.AreEqual(eventCall, wasCalled);
    }

    [UnityTest]
    public IEnumerator EventCalling_WhenPressContinue_CallOnLongPressEvent()
    {
        var inputSignatureMock = Substitute.For<IConcreteInputSignature>();

        var controller = CreateInput();

        bool wasCalled = false;

        controller.Initialize(inputSignatureMock);
        inputSignatureMock.IsPressEnded().Returns(true);
        controller.OnEnded += () => { wasCalled = true; };

        yield return null;

        Assert.AreEqual(true, wasCalled);
    }

    [UnityTest]
    public IEnumerator EventCalling_WhenPressEnded_CallOnEndedEvent()
    {
        var inputSignatureMock = Substitute.For<IConcreteInputSignature>();

        var controller = CreateInput();

        bool wasCalled = false;

        controller.Initialize(inputSignatureMock);
        inputSignatureMock.IsPressed().Returns(true);
        controller.OnLongPress += () => { wasCalled = true; };

        yield return null;

        Assert.AreEqual(true, wasCalled);
    }
}
