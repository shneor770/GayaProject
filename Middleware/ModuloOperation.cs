namespace GayaProject.Middleware
{
    public class ModuloOperation: Operation
    {
        public override string Name => "Modulo";
        public override string Sign => "%";

        public override double OperationTrigger(double feild1, double feild2)
            => feild1 % feild2;
    }
}
