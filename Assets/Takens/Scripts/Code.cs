using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Takens {
    public class Code : MonoBehaviour
    {
        public GameObject Bookshelf;
        public GameObject Black;
        private Image b;
        void Start()
        {
            Inventory.main.code.Add(0, Random.Range(1, 6)); 
            Inventory.main.code.Add(1, Random.Range(1, 6)); 
            Inventory.main.code.Add(2, Random.Range(1, 6)); 
            Inventory.main.code.Add(3, Random.Range(1, 6)); 
            Inventory.main.code.Add(4, Random.Range(1, 6)); 
            Inventory.main.code.Add(5, Random.Range(1, 6));
            Inventory.main.currentCode.Add(0, 0);
            Inventory.main.currentCode.Add(1, 0);
            Inventory.main.currentCode.Add(2, 0);
            Inventory.main.currentCode.Add(3, 0);
            Inventory.main.currentCode.Add(4, 0);
            Inventory.main.currentCode.Add(5, 0);
            Debug.Log(Inventory.main.code[0].ToString() +  Inventory.main.code[1].ToString() + Inventory.main.code[2].ToString() + Inventory.main.code[3].ToString() + Inventory.main.code[4].ToString() + Inventory.main.code[5].ToString());
            b = Black.GetComponent<Image>();
        }
        public void Update()
        {
            if (!Inventory.main.completedGame)
            {
                if (Inventory.main.currentCode[0] == Inventory.main.code[0] &&
                    Inventory.main.currentCode[1] == Inventory.main.code[1] &&
                    Inventory.main.currentCode[2] == Inventory.main.code[2] &&
                    Inventory.main.currentCode[3] == Inventory.main.code[3] &&
                    Inventory.main.currentCode[4] == Inventory.main.code[4] &&
                    Inventory.main.currentCode[5] == Inventory.main.code[5])
                {
                    Inventory.main.completedGame = true;
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>().displayMessage("You win!");
                    StartCoroutine("Win");
                    //COMPLETE GAME LOGIC HERE
                }
            }
        }
        void OnMouseDown()
        {
            if (!Inventory.main.hasItem(ItemType.message))
            {
               if(Inventory.main.selectedItem == ItemType.codeBreaker)
                {
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>().displayMessage("You cracked the code and found a hidden message!");
                    Inventory.main.Set(ItemType.message, true);
                }
               else
                {
                        GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>().displayMessage("The text in this book seems to be encrypted...");
                }
            }
         }
        public IEnumerator Win()
        {
            Black.SetActive(true);
            Bookshelf.GetComponent<Animator>().SetBool("GameOver", true);

            yield return new WaitForSeconds(2.5f);
            b.color = new Color(b.color.r, b.color.g, b.color.b, 0f);
            while (b.color.a < 1f)
            {
                b.color = new Color(b.color.r, b.color.g, b.color.b, b.color.a + .01f);
                yield return null;
            }
           
        }
    }
}