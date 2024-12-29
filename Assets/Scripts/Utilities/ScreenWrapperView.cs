﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Utilities
{
    public class ScreenWrapperView : MonoBehaviour
    {
        private Renderer RendererComponent;
        private bool hasEnteredScreen;
        [SerializeField] private float wrappingOffset = 0.05f;

        private void Start()
        {
            RendererComponent = GetComponent<Renderer>();
            hasEnteredScreen = false;
        }

        private void Update()
        {
            if (!hasEnteredScreen)
                CheckIfEntered();
            else if (RendererComponent.isVisible)
                WrapObjectOnScreen();
        }

        private void CheckIfEntered()
        {
            // Check if the object has entered the Game Screen.
            Vector3 viewPointPosition = Camera.main.WorldToViewportPoint(transform.position);
            bool onScreen = viewPointPosition.x > 0 && viewPointPosition.x < 1 && viewPointPosition.y > 0 && viewPointPosition.y < 1;
            if (onScreen) hasEnteredScreen = true;
        }

        private void WrapObjectOnScreen()
        {
            var viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            var newPosition = transform.position;

            if (viewportPosition.x > 1)
                newPosition.x = -(newPosition.x - wrappingOffset);
            if (viewportPosition.x < 0)
                newPosition.x = -(newPosition.x + wrappingOffset);
            if (viewportPosition.y > 1)
                newPosition.y = -(newPosition.y - wrappingOffset);
            if (viewportPosition.y < 0)
                newPosition.y = -(newPosition.y + wrappingOffset);

            transform.position = newPosition;
        }
    }
}
