using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{
    public class DialogueSystem : MonoBehaviour
    {
        public static DialogueSystem Singleton { get; set; }
        public GameObject dialoguePanel;
        public string npcName;
        public List<string> dialogueLines = new List<string>();

        Button continueButton;
        Text dialogueText, nameText;
        int dialogueIndex;

        void Awake()
        {
            continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
            dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
            nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
            continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );
            dialoguePanel.SetActive(false);


            if (Singleton != null && Singleton != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Singleton = this;
            }
        }

        public void AddNewDialogue(string[] lines, string npcName)
        {
            dialogueIndex = 0;
            dialogueLines = new List<string>(lines.Length);
            dialogueLines.AddRange(lines);
            this.npcName = npcName;
            Debug.Log(dialogueLines.Count);
            CreateDialogue();
        }

        public void CreateDialogue()
        {
            dialogueText.text = dialogueLines[dialogueIndex];
            nameText.text = npcName;
            dialoguePanel.SetActive(true);
        }
        public void ContinueDialogue()
        {
            if (dialogueIndex < dialogueLines.Count - 1)
            {
                dialogueIndex++;
                dialogueText.text = dialogueLines[dialogueIndex];
            }
            else
            {
                dialoguePanel.SetActive(false);
            }
        }
    }
}