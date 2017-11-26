using UnityEngine;
using UnityEngine.Networking;

namespace SurvivalShooter
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerController))]

    public class PlayerSetup : NetworkBehaviour
    {
        [SerializeField] Behaviour[] componentsToDisable;
        [SerializeField] string remoteLayerName = "RemotePlayer";

        Camera sceneCamera;

        void Start ()
        {
            if (!isLocalPlayer)
            {
                DisableComponents();
                AssignRemoteLayer();
            }
            else
            {
                sceneCamera = Camera.main;

                if (sceneCamera != null)
                {
                    sceneCamera.gameObject.SetActive(false);
                }
            }

            GetComponent<Player>().Setup();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public override void OnStartClient ()
        {
            base.OnStartClient();

            string _netID = GetComponent<NetworkIdentity>().netId.ToString();
            Player _player = GetComponent<Player>();

            GameManager.RegisterPlayer(_netID, _player);
        }

        void AssignRemoteLayer ()
        {
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        }

        void DisableComponents ()
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

        void OnDisable ()
        {
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(true);
            }

            GameManager.UnRegisterPlayer(transform.name);
        }
    }
}
