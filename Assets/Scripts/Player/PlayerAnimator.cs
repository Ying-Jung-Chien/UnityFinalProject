using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class PlayerAnimator : MonoBehaviour
    {
        private int idleState;
        private int walkState;
        private int runState;
        private int jumpState;
        private int fallState;
        private int landState;
        private int attackState;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            idleState = Animator.StringToHash("Base Layer.Male Idle");
            walkState = Animator.StringToHash("Base Layer.Male_Sword_Walk");
            runState = Animator.StringToHash("Base Layer.Male Sword Sprint");
            jumpState = Animator.StringToHash("Base Layer.Male Jump Up");
            fallState = Animator.StringToHash("Base Layer.Male Fall");
            landState = Animator.StringToHash("Base Layer.Male Land");
            attackState = Animator.StringToHash("Base Layer.Male Attack 3");

            animator = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(PlayerController.isRising){
                PlayStateIfNotInState(jumpState);
            }
            else if(PlayerController.isFalling){
                if(IsInState(jumpState)){
                    PlayState(fallState);
                }
            }
            else if(PlayerController.isLanding){
                if(IsInState(fallState)){
                    PlayState(landState);
                }
                if(IsInState(landState)){
                    if(CurrentStateDone()) PlayerController.isLanding = false;
                }
            }
            else if(PlayerController.isAttacking){
                if(IsInState(attackState)){
                    if(CurrentStateDone()) PlayerController.isAttacking = false;
                }
                PlayStateIfNotInState(attackState);
                
            }
            else if(PlayerController.isRunning){
                PlayStateIfNotInState(runState);
            }
            else if(PlayerController.isWalking){
                PlayStateIfNotInState(walkState);
            }
            else{
                PlayStateIfNotInState(idleState);
            }
        }

        bool IsInState(int stateHash){
            return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateHash;
        }

        bool CurrentStateDone(){
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f;
        }

        void PlayState(int stateHash){
            animator.Play(stateHash, 0);
        }

        void PlayStateIfNotInState(int stateHash){
            if(!IsInState(stateHash))
                PlayState(stateHash);
        }
    }

}
