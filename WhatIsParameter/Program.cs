namespace WhatIsParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Description desc = new Description();

            int number1 = 10;
            int number2 = 20;

            Console.WriteLine("ValueTypeParam result");
           
            desc.ValueTypeParam(number1, number2);
            Console.WriteLine("[main] first: {0} second :{1}",number1,number2);


            Console.WriteLine("RefTypeParam result");
            desc.RefTypeParam(ref number1, ref number2);
            Console.WriteLine("[main] first: {0} second :{1}", number1, number2);

            Console.WriteLine("OutTypeParam result");
            int number;
            desc.OutTypeParam(out number);
            Console.WriteLine("[main] number: {0} ", number);

            desc.FlexibleTyopeParam(1, 2, 3, 10, 40, 50);
        }
    }
}