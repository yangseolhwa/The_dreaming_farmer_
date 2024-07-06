using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    public Image npcImage;
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    private int currentDialogueIndex = 0;
    private NPCData currentNPCData;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(NPCData npcData)
    {
        currentNPCData = npcData;
        if (currentNPCData != null)
        {
            npcImage.sprite = currentNPCData.npcImage;
            npcNameText.text = currentNPCData.npcName;
            currentDialogueIndex = 0;
            dialogueText.text = currentNPCData.dialogues[currentDialogueIndex];
            dialoguePanel.SetActive(true);
            CameraManager.Instance.SetCameraActive(false);
        }
    }

    public void NextDialogue()
    {
        if (currentNPCData != null)
        {
            currentDialogueIndex++;
            if (currentDialogueIndex < currentNPCData.dialogues.Length)
            {
                dialogueText.text = currentNPCData.dialogues[currentDialogueIndex];
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        CameraManager.Instance.SetCameraActive(true);
    }
}
