using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputSO")]
public class InputSO : ScriptableObject,Controls.IPlayerActions
{
    private Controls _controls;

    public LayerMask whatIsGround;
    
    public  Vector2 MoveInput { get; private set; }
    private Vector2 mousePosition;
    private Vector2 lastMousePostion;

    #region Actions
    public event Action OnAttackEvent;
    public event Action OnDodgeEvent;
        

    #endregion
    
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.Enable();
        }
        _controls.Player.SetCallbacks(this);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>().normalized;
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnAttackEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnDodgeEvent?.Invoke();
    }

    public Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        bool hit = Physics.Raycast(ray,out RaycastHit hitInfo ,Mathf.Infinity, whatIsGround);
        if (hit)
        {
            lastMousePostion = hitInfo.point;
            return hitInfo.point;
        }

        return lastMousePostion;
    }
}
