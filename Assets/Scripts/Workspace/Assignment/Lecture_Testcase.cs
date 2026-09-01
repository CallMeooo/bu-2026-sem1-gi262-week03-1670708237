using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;

using LCT01 = Assignment.StudentSolution.LCT01;
using LCT02 = Assignment.StudentSolution.LCT02;
using LCT03 = Assignment.StudentSolution.LCT03;
using LCT04 = Assignment.StudentSolution.LCT04;
using LCT05 = Assignment.StudentSolution.LCT05;

namespace Assignment
{
    public class Lecture_Testcase
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown()
        {

        }

        #region Lecture

        [Category("Lecture")]
        [Test(Description = "Run LCT01 example - Syntax & Class")]
        public void LCT01_SyntaxClass()
        {
            var testcase = new LCT01.LCT01SyntaxClass();
            testcase.Start();
        }

        [Category("Lecture")]
        [Test(Description = "Run LCT02 example - Class Constructor")]
        public void LCT02_ClassConstructor()
        {
            var testcase = new LCT02.LCT02ClassConstructor();
            testcase.Start();
        }

        [Category("Lecture")]
        [Test(Description = "Run LCT03 example - Inheritance")]
        public void LCT03_Inheritance()
        {
            var testcase = new LCT03.LCT03Inheritance();
            testcase.Start();
        }

        [Category("Lecture")]
        [Test(Description = "Run LCT04 example - Access Modifier")]
        public void LCT04_AccessModifier()
        {
            var testcase = new LCT04.LCT04AccessModifier();
            testcase.Start();
        }

        [Category("Lecture")]
        [Test(Description = "Run LCT05 example - Virtual & Override")]
        public void LCT05_VirtualOverride()
        {
            var testcase = new LCT05.LCT05VirtualOverride();
            testcase.Start();
        }

        #endregion
    }
}
