using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    private DialogueUIManager dialogueUIManager;
    private NPCManager npcManager;

    private void Start()
    {
        dialogueUIManager = FindObjectOfType<DialogueUIManager>();
        npcManager = FindObjectOfType<NPCManager>();
    }

    private void OnMouseDown()
    {
        if (dialogueUIManager != null && npcManager != null)
        {
            string clickedObjectName = gameObject.name;
            NPCData npcData = System.Array.Find(npcManager.npcDataArray, npc => npc.objectName == clickedObjectName);
            if (npcData != null)
            {
                dialogueUIManager.ShowDialogue(npcData);
                Debug.Log("Show NPC Dialogue");
            }
        }
    }
}
