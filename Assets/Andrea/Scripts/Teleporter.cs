using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Teleporter : ActionItem
    {
        public Vector3 TeleportLocation { get; set; }
        [SerializeField]
        private Teleporter[] linkedLocations;
        private TeleporterController TeleporterController { get; set; }

        void Start()
        {
            TeleporterController = FindObjectOfType<TeleporterController>();
            TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
        }

        public override void Interact()
        {
            TeleporterController.ActivateTeleporter(linkedLocations);
        }
    }
}