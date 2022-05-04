namespace WiredBrainCoffee.SpecialCases
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            var container = new Container<int>();

            System.Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            System.Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            System.Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            System.Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCount}");

            container.PrintItem("Hello from generic method in generic class");

            // can't use generics with mathematical operators - should just overload method instead
            var value = Add(2, 3);
            System.Console.WriteLine($"2+3={value}");
            var value2 = Add(2.3, 3.3);
            System.Console.WriteLine($"2.3+3.3={value2}");
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static double Add(double x, double y)
        {
            return x + y;
        }

        class ContainerBase
        {
            public ContainerBase() => InstanceCount++;

            public static int InstanceCount { get; private set; }
        }

        class Container<T> : ContainerBase
        {
            public Container() => InstanceCount++;

            public static int InstanceCount { get; private set; }

            public void PrintItem<TItem>(TItem item)
            {
                System.Console.WriteLine($"Item: {item}");
            }
        }
    }
}