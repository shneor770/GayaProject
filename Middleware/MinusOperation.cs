namespace GayaProject.Middleware
{
    public class MinusOperation : Operation
    {
        public override string Name => "Minus";
        public override string Sign => "-";

        public override double OperationTrigger(double feild1, double feild2)
            => feild1 - feild2;
    }
}
