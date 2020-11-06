using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Alu.Add;
using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week2_LogicGates
{
    class Program
    { 
        static void Main(string[] args)
        {
            // 1) State : (false) + (false) =  (false)
            // 2) State : (false) + (true)  =  (false)
            // 3) State : (true)  + (false) =  (false)
            // 4) State : (true)  + (true)  =  (true)
            //TestCaseMixed1();//AND OR
            //TestCaseMixed2();//NAND NOR
            //TestCaseMixed3();//XNOR XOR
            //TestCaseAND1();
            //TestCaseAND2();
            //TestCaseAND3();
            //TestCaseAND4();
            //TestCaseNOT1();
            //TestCaseNOT2();
            //TestCaseOR1();
            //TestCaseOR2();
            //TestCaseOR3();
            //TestCaseOR4();
            //TestCaseNOR1();
            //TestCaseXOR1();
          //  TestCaseHADD1(); // halfAdder
            TestCaseFADD1(); // fullAdder





        }


        private static void TestCaseMixed1()
        {
            var myMatrixInput = new List<Input>();
            myMatrixInput.Add(new Input() { InputA = true, InputB = true });
            myMatrixInput.Add(new Input() { InputA = false, InputB = true });
            myMatrixInput.Add(new Input() { InputA = true, InputB = false });
            myMatrixInput.Add(new Input() { InputA = false, InputB = false });
            Console.WriteLine("andGate and  orGate Results");
            foreach (var i in myMatrixInput)
            {
                var andGate = new AND();
                var orGate = new OR(); 
                andGate.SetInputA(i.InputA);
                andGate.SetInputB(i.InputB);
                var result = andGate.Output.State;
                Console.WriteLine(result.ToString());
                
                orGate.SetInputA(i.InputA);
                orGate.SetInputB(result);
                var orFinalOutput = orGate.Output.State;
                Console.WriteLine($"{i.InputA}, {i.InputB}, {result}, {i.InputA}, {orFinalOutput}");
               
            }
        }

        private static void TestCaseMixed2()
        {
            var myMatrixInput = new List<Input>();
            myMatrixInput.Add(new Input() { InputA = true, InputB = true });
            myMatrixInput.Add(new Input() { InputA = false, InputB = true });
            myMatrixInput.Add(new Input() { InputA = true, InputB = false });
            myMatrixInput.Add(new Input() { InputA = false, InputB = false });
            Console.WriteLine("NorGate and  NandGate Results");
            foreach (var i in myMatrixInput)
            {
                var norGate = new NOR();
                var nandGate = new NAND();
               
                nandGate.InputA.State = i.InputA;
                nandGate.InputB.State = i.InputB;
                var result = nandGate.Output.State;
                Console.WriteLine(result.ToString());

                norGate.InputA.State = i.InputA;
                norGate.InputB.State = result;
                var orFinalOutput = norGate.Output.State;
                Console.WriteLine($"{i.InputA}, {i.InputB}, {result}, {i.InputA}, {orFinalOutput}");

            }
        }

        private static void TestCaseMixed3()
        {
            var myMatrixInput = new List<Input>();
            myMatrixInput.Add(new Input() { InputA = true, InputB = true });
            myMatrixInput.Add(new Input() { InputA = false, InputB = true });
            myMatrixInput.Add(new Input() { InputA = true, InputB = false });
            myMatrixInput.Add(new Input() { InputA = false, InputB = false });
            Console.WriteLine("XnorGate and  xorGate Results");
            foreach (var i in myMatrixInput)
            {

                var xnorGate = new XNOR();
                var xorGate = new XOR();

                xnorGate.InputA.State = i.InputA;
                xnorGate.InputB.State = i.InputB;
                var result = xnorGate.Output.State;
                Console.WriteLine(result.ToString());

                xorGate.InputA.State = i.InputA;
                xorGate.InputB.State = result;
                var orFinalOutput = xorGate.Output.State;
                Console.WriteLine($"{i.InputA}, {i.InputB}, {result}, {i.InputA}, {orFinalOutput}");

            }
        }
        private static void TestCaseAND1()
        {
            //State 1 false false
            var tester = new AND();
            tester.SetInputA(false);
            tester.SetInputB(false);
            var result = tester.Output;
            Console.WriteLine("True + False AND = " + result.State);
        }

        private static void TestCaseAND2()
        {
            //State 2 false true
            var tester = new AND();
            tester.SetInputA(false);
            tester.SetInputB(true);
            var result = tester.Output;
            Console.WriteLine("True + False AND = " + result.State);
        }

        private static void TestCaseAND3()
        {
            //State 2 false true
            var tester = new AND();
            tester.SetInputA(true);
            tester.SetInputB(false);
            var result = tester.Output;
            Console.WriteLine("True + False AND = " + result.State);
        }




        private static void TestCaseAND4()
        {
            //State 4 true true
            var tester = new AND();
            tester.SetInputA(true);
            tester.SetInputB(true);
            var result = tester.Output;
            Console.WriteLine("True + False AND = " +result.State);
        }


        //If 
        private static void TestCaseNOT1()
        {
            var tester = new NOT();
            tester.SetInputA(false);
            var result = tester.Output;
            Console.WriteLine("True + False NOT = " + result.State);
            //true
        }
        private static void TestCaseNOT2()
        {
            var tester = new NOT();
            tester.SetInputA(true);
            var result = tester.Output;
            Console.WriteLine("True + False NOT = " + result.State);
            //false
        }
        /// <summary>
        /// if one is true in an OR than both is true position doesn't matter
        /// 
        /// </summary>
        private static void TestCaseOR1()
        {
            var tester = new OR();
            tester.SetInputA(true);
            tester.SetInputB(false);
            var result = tester.Output;
            Console.WriteLine("True + False OR = " + result.State);
            // false
        }

        private static void TestCaseOR2()
        {
            var tester = new OR();
            tester.SetInputA(false);
            tester.SetInputB(false);
            var result = tester.Output;
            Console.WriteLine("False + False OR = " + result.State);
            // false
        }

        private static void TestCaseOR3()
        {
            var tester = new OR();
            tester.SetInputA(false);
            tester.SetInputB(true);
            var result = tester.Output;
            Console.WriteLine("False + True OR = " + result.State);
            // false
        }
        private static void TestCaseOR4()
        {
            var tester = new OR();
            tester.SetInputA(true);
            tester.SetInputB(true);
            var result = tester.Output;
            Console.WriteLine("True + True OR = " + result.State);
            // false
        }
        private static void TestCaseNOR1()
        {
            
            //true
            var norGate = new NOR(); 
            norGate.InputA.State = false;
            norGate.InputB.State = false;
            var result = norGate.Output.State;
            Console.WriteLine("False + False NOR = " + result.ToString());

            //false
            norGate.InputA.State = false;
            norGate.InputB.State = true;
            var result2 = norGate.Output.State;
            Console.WriteLine("False + True NOR = " + result2.ToString());

            //false
            norGate.InputA.State = true;
            norGate.InputB.State = true;
            var result3 = norGate.Output.State;
            Console.WriteLine("True + True NOR = " + result3.ToString());

            //false
            norGate.InputA.State = true;
            norGate.InputB.State = false;
            var result4 = norGate.Output.State;
            Console.WriteLine("True + False NOR = " + result4.ToString());

        }

        private static void TestCaseXOR1()
        {

            //true
            var norGate = new XOR();
            norGate.InputA.State = false;
            norGate.InputB.State = false;
            var result = norGate.Output.State;
            Console.WriteLine("False + False XOR = " + result.ToString());

            //false
            norGate.InputA.State = false;
            norGate.InputB.State = true;
            var result2 = norGate.Output.State;
            Console.WriteLine("False + True XOR = " + result2.ToString());

            //false
            norGate.InputA.State = true;
            norGate.InputB.State = true;
            var result3 = norGate.Output.State;
            Console.WriteLine("True + True XOR = " + result3.ToString());

            //false
            norGate.InputA.State = true;
            norGate.InputB.State = false;
            var result4 = norGate.Output.State;
            Console.WriteLine("True + False XOR = " + result4.ToString());

        }

        private static void TestCaseHADD1()
        {

            //false
          
            var halfAdder = new HalfAdder();
            halfAdder.InputA.State = false;
            halfAdder.InputB.State = false;
            var result = halfAdder.CarryOver.State;
            Console.WriteLine("False + False halfAdder = " + result.ToString());

            ////false
            halfAdder.InputA.State = false;
            halfAdder.InputB.State = true;
            var result2 = halfAdder.CarryOver.State;
            Console.WriteLine("False + True halfAdder = " + result2.ToString());

            ////false
            halfAdder.InputA.State = true;
            halfAdder.InputB.State = false;
            var result3 = halfAdder.CarryOver.State;
            Console.WriteLine("True + False halfAdder = " + result3.ToString());

            ////True
            halfAdder.InputA.State = true;
            halfAdder.InputB.State = true;
            var result4 = halfAdder.CarryOver.State;
            Console.WriteLine("False + False halfAdder = " + result4.ToString());

        }

        private static void TestCaseFADD1()
        {

            //false
            var fullAdder = new FullAdder();
            fullAdder.InputA.State = false;
            fullAdder.InputB.State = false;
            var result = fullAdder.CarryOver.State;
            Console.WriteLine("False + False fullAdder = " + result.ToString());

            ////false
            fullAdder.InputA.State = false;
            fullAdder.InputB.State = true;
            var result2 = fullAdder.CarryOver.State;
            Console.WriteLine("False + True fullAdder = " + result2.ToString());

            ////false
            fullAdder.InputA.State = true;
            fullAdder.InputB.State = false;
            var result3 = fullAdder.CarryOver.State;
            Console.WriteLine("True + False fullAdder = " + result3.ToString());

            ////True
            fullAdder.InputA.State = true;
            fullAdder.InputB.State = true;
            var result4 = fullAdder.CarryOver.State;
            Console.WriteLine("False + False fullAdder = " + result4.ToString());

        }




         










    }
}
