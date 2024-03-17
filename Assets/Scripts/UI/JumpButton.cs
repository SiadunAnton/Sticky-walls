using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Domain.Movement.JumpController;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private ILongJumpBehaviour _longJump;
    private bool _isNextPress = false;
    private bool _isPressed = false;

    [Inject]
    public void Initialize(ILongJumpBehaviour longJump)
    {
        _longJump = longJump;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        if ( !_isNextPress)
        {
            _longJump.BaseJump();
            _isNextPress = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        _isNextPress = false;
        _longJump.JumpEnd();
    }

    private void FixedUpdate()
    {
        if (_isPressed)
            _longJump.AdditionalJump();
    }
}
