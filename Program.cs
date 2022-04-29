namespace WiredBrainCoffee.StackApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StackDoubles();
            StackStrings();
            Console.ReadLine();
        }

        private static void StackDoubles()
        {
            var stack = new Stack<double>();
            stack.Push(1.2);
            stack.Push(2.3);
            stack.Push(3.4);

            double sum = 0.0;
            while (stack.Count > 0)
            {
                double item = stack.Pop();
                System.Console.WriteLine($"Item: {item}");
                sum += item;
            }

            Console.WriteLine($"Sum: {sum}");
        }

        private static void StackStrings()
        {
            var stack = new SimpleStack<string>();
            stack.Push("Wired Brain Coffee");
            stack.Push("PluralSight");

            while (stack.Count > 0)
            {
                string item = (string) stack.Pop();
                System.Console.WriteLine($"Item: {item}");
            }
        }
    }
}