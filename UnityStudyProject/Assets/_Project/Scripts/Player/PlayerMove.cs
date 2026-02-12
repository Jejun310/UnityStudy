using UnityEngine;
using UnityEngine.InputSystem;//유니티 엔진 네임스페이스(유니티 기본 기능을 쓰기 위해 선언)

public class PlayerMove : MonoBehaviour //PlayerMove라는 컴포넌트를 정의 MonoBehaviour를 상속해야 유니티 오브젝트에 붙이고 생명주기 함수(Awake, Update 등)를 사용 가능
{
    [SerializeField] private float movespeed = 1f; //개체의 이동속도를 설정할 수 있음 인스펙터에서 값을 바꿀 수 있음 //private라 코드 밖에서 마음대로 값 변경 불가, serializeField를 설정했기 때문에 인스펙터에서만 값 변경 가능

    private CharacterController controller; //CharacterController 컴포넌트를 담아둘 변수 추가
    private Vector2 moveInput;

    private void Awake() //유니티가 오브젝트를 로드하자마자 호출하는 함수
    {
        controller = GetComponent<CharacterController>(); //같은 게임오브젝트에 붙어 있는 CharacterController 컴포넌트를 찾아서 controller 변수에 넣음
    }

    private void Update() // 매 프레임마다 호출하는 함수
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        controller.Move(move * movespeed * Time.deltaTime); //CharacterController 컴포넌트를 통해 이동시킴 (move * movespeed는 속도 적용, Time.deltaTime는 프레임마다 속도 일정하도록 조정)
        //충돌 처리 + 부드러운 이동 가능
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}

/*

 */
