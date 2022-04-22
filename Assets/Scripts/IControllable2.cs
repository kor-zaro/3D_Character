using UnityEngine;

interface IControllable2
{
    void ControllerConnect();   // 컨트롤러가 연결될 때 초기화 시키는 하뭇
    void MoveInput(Vector2 dir);    // 받은 방향입력을 처리하는 함수
    void MoveUpdate();          // Update 함수에서 실제로 움직임을 처리하는 함수
}