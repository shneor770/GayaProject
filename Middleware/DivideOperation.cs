namespace GayaProject.Middleware
{
    public class DivideOperation : Operation
    {
        public override string Name => "Divide";
        public override string Sign => "/";

        public override double OperationTrigger(double feild1, double feild2)
            => feild1 / feild2;
    }
}
