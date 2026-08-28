using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPPlayer : Character
    {
        private InputAction moveAction;

        public void Start()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            PrintInfo();
            GetRemainEnergy();
        }

        public void Update()
        {
            Vector2 direction = moveAction.ReadValue<Vector2>();
            
            // if we call Move() here, it will be called every frame, 
            // which is not what we want. We want to call Move() only when the moveAction is triggered.
            // Move(direction); 
            
            if (moveAction.triggered)
            {
                Move(direction);
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.energy -= AttackPoint;
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }

    }

}