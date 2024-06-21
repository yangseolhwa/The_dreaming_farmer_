using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handPosition; // 손 위치를 나타내는 Transform

    private GameObject pickedObject; // 플레이어가 현재 들고 있는 오브젝트 저장

    void Update()
    {
        // E 키를 눌러 오브젝트를 줍기 시도
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupObject();
        }

        // Q 키를 눌러 오브젝트 버리기
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
        }
    }

    void TryPickupObject()
    {
        // 주변에 있는 모든 Collider를 가져오기 (여기서는 플레이어 주변에서 찾음)
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); // 반경 2 유니티 단위 내

        foreach (Collider col in colliders)
        {
            // 부모 오브젝트에 hoe 태그가 있는지 확인
            Transform parentTransform = col.transform.parent;
            if (parentTransform != null && parentTransform.CompareTag("Tool"))
            {
                // 이미 오브젝트를 들고 있는 경우 무시
                if (pickedObject != null)
                    return;

                // 부모 오브젝트를 들기
                pickedObject = parentTransform.gameObject;

                // HandlePosition 태그를 가진 자식 오브젝트를 찾기
                Transform handlePosition = null;
                foreach (Transform child in pickedObject.transform)
                {
                    if (child.CompareTag("HandlePosition"))
                    {
                        handlePosition = child;
                        break;
                    }
                }

                if (handlePosition == null)
                {
                    Debug.LogWarning("HandlePosition 태그를 가진 자식 오브젝트를 찾을 수 없습니다.");
                    return;
                }

                // 손잡이 위치를 손 위치로 이동
                pickedObject.transform.parent = handPosition; // 손 위치의 자식으로 설정

                // 현재 회전값 유지하고 손잡이 위치를 손 위치에 맞추기
                Vector3 originalPosition = pickedObject.transform.position; // 오브젝트의 원래 위치 저장
                Quaternion originalRotation = pickedObject.transform.rotation; // 오브젝트의 원래 회전값 저장

                pickedObject.transform.rotation = handPosition.rotation; // 손 위치와 같은 회전으로 설정

                Vector3 offset = handlePosition.position - pickedObject.transform.position;
                pickedObject.transform.position = handPosition.position - offset; // 손잡이 위치를 손 위치로 이동

                // 원래 회전값 유지
                pickedObject.transform.rotation = originalRotation;

                // Rigidbody가 있으면 kinematic으로 설정하여 물리 영향을 받지 않도록 함
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.isKinematic = true;

                // 여기서 다른 작업을 수행할 수 있음 (예: 오브젝트 활성화/비활성화, 물리적 처리 등)

                break; // 하나만 들기
            }
        }
    }

    void DropObject()
    {
        if (pickedObject != null)
        {
            // 오브젝트를 손 위치에서 떼어내고 중력 영향을 받도록 설정
            pickedObject.transform.parent = null;
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = false; // 중력 영향 받도록 설정

            pickedObject = null; // 플레이어가 들고 있는 오브젝트 초기화
        }
    }
}
