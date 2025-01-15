namespace GayaProject.Middleware
{
    public abstract class Operation
    {
        public abstract string Name { get; }
        public abstract string Sign { get; }

        public abstract double OperationTrigger(double feild1, double feild2);
    }
}
