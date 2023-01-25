using CodeBase.InputService;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CharacterController characterController;
    
    private IInputService _inputService;

    private void Awake() => 
        _inputService = new StandaloneInput();

    private void Update() => 
        characterController.Move(GetMotion());


    private Vector3 GetMotion() => 
        GetInputAxisToWorldSpace() * speed * Time.deltaTime; 
    
    private Vector3 GetInputAxisToWorldSpace() =>
        new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
}
