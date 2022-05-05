using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Sprite hand;
    [SerializeField] private Sprite investigate;
    [SerializeField] private Sprite operate;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public void Start()
    {
        //�ڷ�ƾ�� ����մϴ�. TargetCursor()�Լ��� ȣ���մϴ�.
        StartCoroutine("MyCursor");
        spriteRenderer = GetComponent<SpriteRenderer>();
        ToHand();
        mainCamera = Camera.main;
    }
    //MyCursor()��� �̸��� �ڷ�ƾ�� ���۵˴ϴ�.
    IEnumerator MyCursor()
    {
        //��� �������� �Ϸ�� ������ ������״� �������� �Ϸ�Ǹ�
        //���� �޶�� ����Ƽ ������ �� ��Ź�ϰ� ����մϴ�.
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = -5f;
        transform.position = mouseWorldPosition;
    }

    public void ToInvestigate()
    {
        spriteRenderer.sprite = investigate;
    }

    public void ToOperate()
    {
        spriteRenderer.sprite = operate;
    }
    public void ToHand()
    {
        spriteRenderer.sprite = hand;
    }
}
