using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelect : StateMachineBehaviour  // StateMachineBehaviour을 상속 받아 
{
    // OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // 새로운 상태로 변할 때 실행

    // OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // 처음과 마지막 프레임을 제외한 각 프레임 단위로 실행

    // OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // 상태가 다음 상태로 바뀌기 직전에 실행

    // OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // MonoBehaviour.OnAnimatorMove 직후에 실행

    // OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // MonoBehaviour.OnAnimatorIK 직후에 실행

    // OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    // 스크립트가 부착된 상태 기계로 전환이 왔을때 실행

    // OnStateMachineExit(Animator animator, int stateMachinePathHash)
    // 스크립트가 부착된 상태 기계에서 빠져나올때 실행


    public float maxIdleInterval = 3.0f;
    public float minIdleInterval = 2.0f;
    public float waitTime = 2.0f;
    public float normalTime = 0.0f;

    private bool isSelect = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime = Random.Range(minIdleInterval, maxIdleInterval);
        animator.SetInteger("IdleSelect", 0);  // 한번 실행되고 0으로 다시 초기화
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        normalTime = stateInfo.normalizedTime;
        if(stateInfo.normalizedTime>waitTime && !isSelect && !animator.IsInTransition(0)) // 한바퀴가 5초보다 길면
        {
            animator.SetInteger("IdleSelect", IdleSelect());
            isSelect = false;
        }
    }

    int IdleSelect()
    {
        isSelect = true;

        float ran = Random.Range(0.0f, 1.0f);
        int index = 0;

        if (ran < 0.5f)
        {
            index = 1;
        }

        else if (ran < 0.7f)
        {
            index = 2;
        }

        else if (ran < 0.8f)
        {
            index = 3;
        }

        else
        {
            index = 4;
        }

        return index;
    }
}
