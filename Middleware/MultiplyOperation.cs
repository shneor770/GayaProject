namespace GayaProject.Middleware
{
    public class MultiplyOperation : Operation
    {
        public override string Name => "Multiply";
        public override string Sign => "*";

        public override double OperationTrigger(double feild1, double feild2)
            => feild1 * feild2;
    }
}
