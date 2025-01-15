namespace GayaProject.Middleware
{
    public class DiscountOperation : Operation
    {
        public override string Name => "Discount";
        public override string Sign => "$";

        public override double OperationTrigger(double feild1, double feild2)
        {
            var calc = (feild1 / 100) * feild2;
            return feild1 - calc;
        }
    }
}
