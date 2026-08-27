using UnityEngine;


namespace Assignment.StudentSolution.LCT05
{
    public class Animal
    {
        // 0. make MakeSound method to virtual method
        public void MakeSound()
        {
            Debug.Log("Generic animal sound");
        }
    }

    public class Dog
    {
        // student code here ...
        // 1. declare overridden MakeSound() method

        // student code ends ...
    }

    public class Cat
    {
        // student code here ...
        // 2. declare overridden MakeSound() method

        // student code ends ...    
    }



    public class LCT05VirtualOverride
    {
        public void Start()
        {
            // 3. create instance of Dog and call MakeSound()

            // 4. create instance of Cat and call MakeSound()

            // 5. create instance of Animal and call MakeSound()
        }
    }
}
