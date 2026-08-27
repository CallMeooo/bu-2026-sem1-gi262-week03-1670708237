using System.Globalization;
using UnityEngine;

namespace Assignment.StudentSolution.LCT03
{
    public class Animal
    {
        public string name;

        public void MakeSound()
        {
            Debug.Log($"Animal {name} is making sound");
        }
    }

    // class Dog inherits from Animal
    public class Dog
    {

    }

    // class Bird inherits from Animal
    public class Bird
    {

    }

    public class LCT03Inheritance
    {

        public void Start()
        {
            // 1. สร้าง instance ของ class Dog โดยกำหนดชื่อตัวแปรว่า dog
            // + กำหนดชื่อ (name) ว่า "Buddy"
            // + เรียกใช้ method MakeSound() ของ dog
            // + เรียกใช้ method Walk() ของ dog
            Dog dog = new Dog();


            // 2. สร้าง instance ของ class Bird โดยกำหนดชื่อตัวแปรว่า bird
            // + กำหนดชื่อ (name) ว่า "Twitty"
            // + เรียกใช้ method MakeSound() ของ bird
            // + เรียกใช้ method Fly() ของ bird
            Bird bird = new();

        }
    }
}
