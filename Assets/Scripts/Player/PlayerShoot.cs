using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace SurvivalShooter
{
    public class PlayerShoot : NetworkBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private LayerMask mask;

        public PlayerWeapon weapon;
       
        private const string PLAYER_TAG = "Player";
       
        void Start ()
        {
            if (cam == null)
            {
                Debug.LogError("PlayerShoot: No camera referenced!");

                this.enabled = false;
            }
        }

        void Update ()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        [Client]
        void Shoot ()
        {
            RaycastHit _hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
            {
                if (_hit.collider.tag == PLAYER_TAG)
                {
                    CmdPlayerShot(_hit.collider.name, weapon.damage);
                }
            }
        }

        [Command]
        void CmdPlayerShot (string _playerID, int _damage)
        {
            Debug.Log(_playerID + "has been shot.");

            Player _player = GameManager.GetPlayer(_playerID);

            _player.RpcTakeDamage(_damage);
        }
    }
}
