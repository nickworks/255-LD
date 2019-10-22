using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuTutKey : MonoBehaviour
    {
        public float timer = 0;
        public float KeySpawnTime = 600;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1);
            GetComponent<BoxCollider2D>().enabled = false;
            if (BreuInventory.main.tutKey == true)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            timer += 1 + Time.deltaTime;
            if (timer >= KeySpawnTime)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, .01f);
            }
        }

        void OnMouseDown()
        {
            BreuInventory.main.tutKey = true;
            Destroy(gameObject);
        }
    }
}