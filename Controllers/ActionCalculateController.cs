using GayaProject.Data;
using GayaProject.Middleware;
using Microsoft.AspNetCore.Mvc;
using GayaProject.Models;

namespace GayaProject.Controllers
{
    [ApiController]
    [Route("api/gaya/[controller]")]
    public class ActionCalculateController : ControllerBase
    {
        public static readonly List<Operation> operations = new List<Operation>
        {
            new PlusOperation(),
            new MinusOperation(),
            new MultiplyOperation(),
            new DivideOperation(),
            new ModuloOperation(),
            new DiscountOperation()
        };

        public readonly ProcessActionDbContext _context;

        public ActionCalculateController(ProcessActionDbContext context)
            => _context = context;

        [HttpGet("loadOperations")]
        public IActionResult LoadOperations()
        {
            var operationsTypes = operations.Select(operate => operate.Name).ToList();
            return Ok(operationsTypes);
        }
        
        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] BlockData data)
        {
            var operate = operations.FirstOrDefault(
                operate => operate.Name.Equals(data.Operation));

            if (operate != null)
            {
                var res0 = operate.OperationTrigger(data.Feild1, data.Feild2);
                var res = Math.Round(res0, 2);


                InsertDataToDB(data, operate, res);

                var lastAction =  PullLastAction3(operate);

                int currentMonth =  PullCurrentMonth(operate);

                var minMaxAvg =  PullMinMaxAvg(operate);

                return Ok(new
                {
                    res,
                    lastAction,
                    currentMonth,
                    minMaxAvg
                });
            }
            else
                return BadRequest("operate not found");
        }

        private void InsertDataToDB(BlockData data, Operation operate, double res)
        {
            ProcessAction pa = new ProcessAction
            {
                Feild1 = data.Feild1.ToString(),
                Feild2 = data.Feild2.ToString(),
                Operations = operate.Sign,
                Result = res,
                AddedAt = DateTime.Now,
            };


            _context.ProcessAction.Add(pa);
            _context.SaveChanges();
        }

        private List<ProcessAction> PullLastAction3(Operation operation)
        {
            return _context.ProcessAction
                   .Where(operate => operate.Operations == operation.Sign)
                   .OrderByDescending(operate => operate.ProcessActionId)
                   .Take(3)
                   .ToList();
        }

        private int PullCurrentMonth(Operation operation)
        {
            return _context.ProcessAction
                .Where(operate => operate.Operations == operation.Sign && operate.AddedAt.Month == DateTime.Now.Month)
                .Count();
        }

        private object PullMinMaxAvg(Operation operation)
        {
            var where = _context.ProcessAction.Where(operate => operate.Operations == operation.Sign);
            var minMaxAvg = new
            {
                Min = where.Min(a => a.Result),
                Max = where.Max(a => a.Result),
                Avg = where.Average(a => a.Result)
            };

            return minMaxAvg;
        }
    }
}
