using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;

    public float textSpeed = 0.1f;
    public float speedMultiplier = 0.5f;

    public KeyCode dialogueInput = KeyCode.F;

    public string names;

    public string[] dialogueLines;

    public bool speedMultiplied;
    public bool dialogueActive;
    public bool dialogueEnded;
    public bool outOfRange = true;

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);
        if (dialogueActive)
        {
            dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
        nameText.text = names;
        if (Input.GetKeyDown(dialogueInput))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }
        StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
        if (!outOfRange)
        {
            int dialogueLength = dialogueLines.Length;
            int dialogueIndex = 0;

            while (dialogueIndex < dialogueLength || !speedMultiplied)
            {
                if (!speedMultiplied)
                {
                    speedMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[dialogueIndex++]));

                    if (dialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }

            while (true)
            {
                if (Input.GetKeyDown(dialogueInput) && !dialogueEnded) 
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();

        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (!outOfRange)
        {
            int stringLength = stringToDisplay.Length;
            int charIndex = 0;

            dialogueText.text = "";

            while (charIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[charIndex];
                charIndex++;
                if (charIndex < stringLength)
                {
                    if (Input.GetKey(dialogueInput))
                    {
                        yield return new WaitForSeconds(textSpeed * speedMultiplier);
                    }
                    else
                    {
                        yield return new WaitForSeconds(textSpeed);
                    }
                }
                else
                {
                    dialogueEnded = false;
                    break;
                }

            }
            while (true)
            {
                if (Input.GetKeyDown(dialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            speedMultiplied = false;
            dialogueText.text = "";
        }

    }

    public void DropDialogue()
    {
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        speedMultiplied = false;
        dialogueActive = false;
        StopAllCoroutines();
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
    }
}
