namespace GayaProject.Middleware
{
    public class PlusOperation : Operation
    {
        public override string Name => "Plus";
        public override string Sign => "+";

        public override double OperationTrigger(double feild1, double feild2)
            => feild1 + feild2;
    }
}
