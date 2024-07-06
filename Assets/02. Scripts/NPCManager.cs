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
                npcName = "이장 올리버",
                npcImage = oliverSprite,
                dialogues = new string[]
                {
                    "어서 와! 나는 이 마을의 이장, 올리버라고 해. 렉스가 네가 온다고 말해놨어. 여기서의 생활이 처음이라면 천천히 배워가도 돼. 너만의 속도로 적응해가며, 마음의 여유를 찾아보렴.",
                    "농사일이든, 마을 생활이든, 어려운 점이 있으면 언제든지 나에게 도움을 청하거라. 이 마을에서의 새로운 시작을 진심으로 환영하며, 네가 여기서 행복을 찾기를 바란다.",
                    "자, 이제 우리도 한 가족이니까, 마음 편히 지내보세!"
                }
            },
            new NPCData
            {
                objectName = "Sophie",
                npcName = "소피",
                npcImage = sophieSprite,
                dialogues = new string[]
                {
                    "안녕! 오늘 하루는 어땠어? 밭일이나 낚시는 잘 되고 있니?",
                    "항상 건강하고 행복한 날들이 되길 바래."
                }
            },
            new NPCData
            {
                objectName = "David",
                npcName = "데이비드",
                npcImage = davidSprite,
                dialogues = new string[]
                {
                    "안녕하시게나 오늘도 좋은 물건들이 많이 들어왔다네."
                }
            },
            new NPCData
            {
                objectName = "Rex",
                npcName = "삼촌 렉스",
                npcImage = rexSprite,
                dialogues = new string[]
                {
                    "안녕, 조카야! 오늘은 어떤 모험을 했어? 낚시터에서 큰 물고기라도 잡았나? 아니면 밭에서 새로운 작물을 수확했나?",
                    "요즘은 날씨가 좋아서 야외 활동하기 딱 좋은 시기야. 나는 오늘 새로운 낚싯대를 만들어봤어. 나중에 시간 나면 같이 낚시 가자.",
                    "아, 그리고 밤에는 별이 정말 잘 보이니까, 하늘도 한번 올려다보렴. 여유로운 시간을 즐기는 거야."
                }
            }
        };
    }
}
