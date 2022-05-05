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
        //코루틴을 사용합니다. TargetCursor()함수를 호출합니다.
        StartCoroutine("MyCursor");
        spriteRenderer = GetComponent<SpriteRenderer>();
        ToHand();
        mainCamera = Camera.main;
    }
    //MyCursor()라는 이름의 코루틴이 시작됩니다.
    IEnumerator MyCursor()
    {
        //모든 렌더링이 완료될 때까지 대기할테니 렌더링이 완료되면
        //깨워 달라고 유니티 엔진에 게 부탁하고 대기합니다.
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
