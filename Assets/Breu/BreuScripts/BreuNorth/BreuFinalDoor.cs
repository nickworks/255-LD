using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breu
{
    public class BreuFinalDoor : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnMouseUp()
        {
            if (BreuInventory.main.hasKey == true)
            {
                SceneManager.LoadScene("BreuSceneEnd", LoadSceneMode.Single);
            }
        }
    }
}