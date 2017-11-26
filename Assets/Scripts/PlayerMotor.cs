using UnityEngine;

namespace SurvivalShooter
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMotor : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float cameraRotationLimit = 85f;

        private Rigidbody rigid;
        private Vector3 velocity = Vector3.zero;
        private Vector3 rotation = Vector3.zero;
        private Vector3 thrusterForce = Vector3.zero;
        private float cameraRotationX = 0f;
        private float currentCameraRotationX = 0f;

        // Use this for initialization
        void Start ()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Run every physics iteration
        void FixedUpdate ()
        {
            PerformMovement();
            PerformRotation();
        }

        // Gets a movement vector
        public void Move (Vector3 _velocity)
        {
            velocity = _velocity;
        }

        // Gets a rotational vector
        public void Rotate (Vector3 _rotation)
        {
            rotation = _rotation;
        }

        // Gets a rotational vector for the camera
        public void RotateCamera (float _cameraRotationX)
        {
            cameraRotationX = _cameraRotationX;
        }

        // Gets a force vector for the thrusters
        public void ApplyThruster (Vector3 _thrusterForce)
        {
            thrusterForce = _thrusterForce;
        }

        // Perform movement based on the velocity variable
        void PerformMovement ()
        {
            if (velocity != Vector3.zero)
            {
                rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
            }

            if (thrusterForce != Vector3.zero)
            {
                rigid.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
            }
        }

        // Perform rotation
        void PerformRotation ()
        {
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(rotation));

            if (cam != null)
            {
                // Set the rotation and clamp it
                currentCameraRotationX -= cameraRotationX;
                currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

                // Apply the rotation to the transform of the camera
                cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
            }
        }
    }
}
