using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpAmount = 20f;

    public enum State {
        none,
        idle,
        jump
    }

    [Header("Debug")]
    public State state = State.none;
    public State nextState = State.none;
    private float stateTime;

    public bool landed = false;
    [System.NonSerialized] public Rigidbody rigid;
    private Transform camt;

    private void Start() {
        camt = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();

        state = State.none;
        nextState = State.idle;
        stateTime = 0f;
    }

    private void Update() {
        //0. 글로벌 상황 판단
        stateTime += Time.deltaTime;
        CheckLanded();
        //insert code here...

        //1. 스테이트 전환 상황 판단
        if (nextState == State.none) {
            switch (state) {
                case State.idle:
                    if (landed) {
                        if (Input.GetKey(KeyCode.Space)) {
                            nextState = State.jump;
                        }
                    }
                    break;
                case State.jump:
                    if (landed) nextState = State.idle;
                    break;
                //insert code here...
            }
        }


        //2. 스테이트 초기화
        if (nextState != State.none) {
            state = nextState;
            nextState = State.none;
            switch (state) {
                case State.jump:
                    rigid.AddForce(Vector3.up * jumpAmount, ForceMode.VelocityChange);
                    break;
                //insert code here...
            }
            stateTime = 0f;
        }

        //3. 글로벌 & 스테이트 업데이트
        UpdateInput();
        //insert code here...
    }

    //땅에 닿았는지 여부를 확인하고 landed를 설정해주는 함수
    private void CheckLanded() {

    }

    private void UpdateInput() {

    }

    //카메라 기준으로 앞과 우측 벡터를 계산해주는 함수
    private Vector3 ForwardVector() {
        Vector3 v = camt.forward;
        v.y = 0;
        v.Normalize();
        return v;
    }

    private Vector3 RightVector() {
        Vector3 v = camt.right;
        v.y = 0;
        v.Normalize();
        return v;
    }
}
