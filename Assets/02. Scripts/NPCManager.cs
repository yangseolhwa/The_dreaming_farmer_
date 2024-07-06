using UnityEngine;

[System.Serializable]
public class NPCData
{
    public string objectName;
    public string npcName;
    public Sprite npcImage;
    [TextArea(3, 10)]
    public string[] dialogues;
}

public class NPCManager : MonoBehaviour
{
    public NPCData[] npcDataArray;

    // Example data initialization directly in the script
    public Sprite oliverSprite; // Set these from the Unity editor
    public Sprite sophieSprite;
    public Sprite davidSprite;
    public Sprite rexSprite;

    private void Awake()
    {
        npcDataArray = new NPCData[]
        {
            new NPCData
            {
                objectName = "Oliver",
                npcName = "���� �ø���",
                npcImage = oliverSprite,
                dialogues = new string[]
                {
                    "� ��! ���� �� ������ ����, �ø������ ��. ������ �װ� �´ٰ� ���س���. ���⼭�� ��Ȱ�� ó���̶�� õõ�� ������� ��. �ʸ��� �ӵ��� �����ذ���, ������ ������ ã�ƺ���.",
                    "������̵�, ���� ��Ȱ�̵�, ����� ���� ������ �������� ������ ������ û�ϰŶ�. �� ���������� ���ο� ������ �������� ȯ���ϸ�, �װ� ���⼭ �ູ�� ã�⸦ �ٶ���.",
                    "��, ���� �츮�� �� �����̴ϱ�, ���� ���� ��������!"
                }
            },
            new NPCData
            {
                objectName = "Sophie",
                npcName = "����",
                npcImage = sophieSprite,
                dialogues = new string[]
                {
                    "�ȳ�! ���� �Ϸ�� ���? �����̳� ���ô� �� �ǰ� �ִ�?",
                    "�׻� �ǰ��ϰ� �ູ�� ������ �Ǳ� �ٷ�."
                }
            },
            new NPCData
            {
                objectName = "David",
                npcName = "���̺��",
                npcImage = davidSprite,
                dialogues = new string[]
                {
                    "�ȳ��ϽðԳ� ���õ� ���� ���ǵ��� ���� ���Դٳ�."
                }
            },
            new NPCData
            {
                objectName = "Rex",
                npcName = "���� ����",
                npcImage = rexSprite,
                dialogues = new string[]
                {
                    "�ȳ�, ��ī��! ������ � ������ �߾�? �����Ϳ��� ū ������ ��ҳ�? �ƴϸ� �翡�� ���ο� �۹��� ��Ȯ�߳�?",
                    "������ ������ ���Ƽ� �߿� Ȱ���ϱ� �� ���� �ñ��. ���� ���� ���ο� ���˴븦 �����þ�. ���߿� �ð� ���� ���� ���� ����.",
                    "��, �׸��� �㿡�� ���� ���� �� ���̴ϱ�, �ϴõ� �ѹ� �÷��ٺ���. �����ο� �ð��� ���� �ž�."
                }
            }
        };
    }
}
