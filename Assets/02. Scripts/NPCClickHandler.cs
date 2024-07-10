using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    private DialogueUIManager dialogueUIManager;
    private NPCManager npcManager;
 
    private void Awake()
    {
        dialogueUIManager = FindObjectOfType<DialogueUIManager>();
        npcManager = FindObjectOfType<NPCManager>();

        if (dialogueUIManager == null) Debug.LogError("DialogueUIManager is null in Awake");
        if (npcManager == null) Debug.LogError("NPCManager is null in Awake");
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown triggered");
        if (dialogueUIManager != null && npcManager != null)
        {
            Debug.Log("Managers found");
            string clickedObjectName = gameObject.name;
            NPCData npcData = System.Array.Find(npcManager.npcDataArray, npc => npc.objectName == clickedObjectName);
            if (npcData != null)
            {
                Debug.Log("NPC data found for: " + clickedObjectName);

                dialogueUIManager.ShowDialogue(npcData);

                Debug.Log("Show NPC Dialogue");

                PlayNPCSound(npcData.objectName);
            }
            else
            {
                Debug.LogError("No NPC data found for: " + clickedObjectName);
            }
        }
        else
        {
            if (dialogueUIManager == null) Debug.LogError("DialogueUIManager is null");
            if (npcManager == null) Debug.LogError("NPCManager is null");
        }
    }

    private void PlayNPCSound(string npcName)
    {
        switch (npcName)
        {
            case "Oliver":
                SoundManager.Instance.PlayOliverSFX();
                break;

            case "Sophie":
                SoundManager.Instance.PlaySophieSFX();
                break;

            case "Rex":
                SoundManager.Instance.PlayRexSFX();
                break;

            case "David":
                SoundManager.Instance.PlayDavidSFX();
                break;

        }
    }

}
