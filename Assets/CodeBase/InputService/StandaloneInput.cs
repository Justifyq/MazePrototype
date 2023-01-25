﻿using UnityEngine;

namespace CodeBase.InputService
{
    public class StandaloneInput : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        public Vector2 Axis => UnityAxis();

        private Vector2 UnityAxis() => 
            new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}