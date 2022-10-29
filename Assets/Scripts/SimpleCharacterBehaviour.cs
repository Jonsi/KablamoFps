using System;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _jumpHeight = 1;
    [SerializeField] 
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveUsingInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controller.Move(Vector3.up * _jumpHeight);
        }
        
        
        
    }

    private void MoveUsingInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontal, 0f, vertical).normalized;
        _controller.Move(direction * (_moveSpeed * Time.deltaTime));
    }
}
