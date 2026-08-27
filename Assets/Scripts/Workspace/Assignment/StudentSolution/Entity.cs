using UnityEngine;

namespace Assignment.StudentSolution
{
    public class Entity
    {
        public string name;
        private Vector3 position;
        protected int health;

        public virtual void Update()
        {
        }

        protected virtual void TakeDamage(int damage)
        {
        }

        private void Move(Vector3 direction)
        {
        }
    }
}
