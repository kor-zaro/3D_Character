using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   
    public GameObject targetObject = null;

    IControllable2 targetControl = null;

    private void Start()
    {
        SetTarget(targetObject);
    }

    void SetTarget(GameObject _newTarget)
    {
        if (_newTarget != null)
        {
            targetObject = _newTarget;                        // 게임 오브젝트 타겟에 매개변수 넣고
            targetControl = targetObject.GetComponent<IControllable2>();
            if (targetControl != null)
            {
                targetControl.ControllerConnect();
            }
        }

        else
        {
            targetObject = null;
            targetControl = null;
        }
        
    }

    private void OnValidate() // 인스펙터에서 값이 변경될 경우 호출되는 함수 (에디터 에서만 호출 됨)
    {
        SetTarget(targetObject);
    }

    public void OnMove(InputAction.CallbackContext context) // input System의 Move랑 연동시키기 위함
    {
        
        targetControl?.MoveInput(context.ReadValue<Vector2>());
   

        //inputDir = context.ReadValue<Vector2>();         // 기능 연결할 때
        // Debug.Log(dir);

        //controller.Move(target.transform.forward * dir.y * Time.deltaTime * moveSpeed);
        
    }

    private void Update()
    {
        targetControl?.MoveUpdate();
    }
}
