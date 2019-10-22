using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{
    public class TeleporterController : MonoBehaviour
    {
        private Button button;
        private Teleporter[] teleporters;
        private Player player;
        private GameObject panel;

        // Start is called before the first frame update
        void Start()
        {
            player = FindObjectOfType<Player>();
            panel = transform.Find("Panel_Teleporters").gameObject;
        }

        public void ActivateTeleporter(Teleporter[] teleporters)
        {
            panel.SetActive(true);
            for (int i = 0; i < teleporters.Length; i++)
            {
                Button teleportButton = Instantiate(button, panel.transform);
                teleportButton.GetComponentInChildren<Text>().text = teleporters[i].name;
                int x = i;
                teleportButton.onClick.AddListener(delegate { OnTeleportButtonClick(x, teleporters[x]); });
            }
        }

        void OnTeleportButtonClick(int locationIndex, Teleporter location)
        {
            player.transform.position = location.TeleportLocation;
            panel.SetActive(false);

        }

        void Update()
        {

        }
    }
}