using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float senesitivity = 1f;

    private Image imageBackGround; // 조이스틱 배경 이미지
    private Image imageController; // 조이스틱 컨트롤러 이미지
    private Vector2 touchPosition; // 조이스틱 컨트롤러의 방향 정보

    // touchPosition 프로퍼티 구축
    public float Horizontal { get { return touchPosition.x * senesitivity; }}
    public float Vertical { get { return touchPosition.y * senesitivity; }}

    private void Awake()
    {
        // 조이스틱 배경과 컨트롤러 초기화
        imageBackGround = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // VirtualJoyStick 스크립트를 가지고 있는 오브젝트를 터치했을 때 1회 실행
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // VirtualJoyStick 스크립트를 가지고 있는 오브젝트를 터치하고 뗐을 때 1회 실행
        // 터치 종료시 조이스틱 컨트롤러의 위치를 중앙으로 복귀
        imageController.rectTransform.anchoredPosition = Vector2.zero;
        // 다른 오브젝트에서 이동방향으로 사용하기 실제 이동방향 초기화
        touchPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // VirtualJoyStick 스크립트를 가지고 있는 오브젝트 터치하고 드래그 상태일때 실행
        touchPosition = Vector2.zero;

        // 조이스틱의 위치가 어디에 있든 동일한 값을 연산하기 위해서     
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(imageBackGround.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            // touchPosition 의 위치 값을 이미지 크기로 정규화 [0, 1]
            touchPosition.x = (touchPosition.x / imageBackGround.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / imageBackGround.rectTransform.sizeDelta.y);

            // touchPosition 값 2차 정규화 [-n, +n]
            // 왼쪽(-1), 중심(0), 오른쪽(1)로 변경하기 위해서 touchPosition.x*2 - 1
            // 아래(-1), 중심(0), 위(1)로 변경하기 위해서 touchPosition.y*2 - 1
            // 위 수식은 Pivot 위치에 따라 달라지고 현재 조이스틱이 위치한 좌측하단 기준입니다.
            touchPosition = new Vector2(touchPosition.x*2 - 1, touchPosition.y*2 - 1);

            // touchPosition 값 3차 정규화 [-1, 1]
            // 컨트롤러가 배경 밖으로 터치가 나가면 -1 ~ 1 보다 큰 값이 나오기 때문에
            // 큰 값이 나오지 않도록 normalized 를 이용해서 정규화
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            // 컨트롤러 이미지 이동
            // touchPosition은 -1 ~ 1 사이의 데이터이기 때문에 그대로 사용하게 되면
            // 컨트롤러의 움직임 보기가 어렵기 때문에
            // 배경 크기를 곱하여 사용한다.(단, 중심을 기준으로 왼쪽은 -1 오른쪽은 +1이기 때문에 배경크기보다 작게 하기 위해서 나눠줌)
            Vector2 controllerPosition = new Vector2(touchPosition.x * imageBackGround.rectTransform.sizeDelta.x / 3,
                                                    touchPosition.y * imageBackGround.rectTransform.sizeDelta.y / 3);

            imageController.rectTransform.anchoredPosition = controllerPosition;
        }
    }
}
