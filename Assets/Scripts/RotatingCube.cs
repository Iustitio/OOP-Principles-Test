using System;

namespace DefaultNamespace
{
    
    // INHERITANCE
    public class RotatingCube : RotatingShape
    {
        private void Start()
        {
            RotationSpeedX = 10.0f;
            RotationSpeedY = 10.0f;
            RotationSpeedZ = 10.0f;
        }
    }
}