using UnityEngine;

namespace DefaultNamespace
{
    
    // INHERITANCE
    public class RotatingSphere : RotatingShape
    {
        private void Start()
        {
            RotationSpeedX = -5.0f;
            RotationSpeedY = -2.0f;
            RotationSpeedZ = -15.0f;
        }

        // POLYMORPHISM
        protected override bool HasValidSize(Vector3 newScale)
        {
            // We also want to make sure the new size will not deform the sphere, so all scale multipliers must be equal
            bool areScaleMultipliersEqual = newScale.x == newScale.y && newScale.y == newScale.z;
            return base.HasValidSize(newScale) && areScaleMultipliersEqual;
        }
    }
}