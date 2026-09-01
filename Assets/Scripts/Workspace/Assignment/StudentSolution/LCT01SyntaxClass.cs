using UnityEngine;


namespace Assignment.StudentSolution.LCT01
{
    public class Car
    {
        //Fields
        public string Name;
        public float Speed;
        public string Color;
        //Method
        public void Move() 
        {
            Debug.Log("Car is moving");
        }
        public void Turn()
        {
            Debug.Log("Car is turning");
        }
        public void Honk ()
        {
            Debug.Log("Car is honking");
        }
    }

    public class LCT01SyntaxClass
    {
        public void Start()
        {
            // Student code start HERE ...

            Car car = new Car();
            Car car2 = new ();

            car.Name = "Honda";
            car.Speed = 80;
            car.Color = "Black";

            car.Move();
            car.Turn();
            car.Honk();

            // Student code ends HERE 
        }
    }
}
