using DAMS.EntityFrameworkCore;

namespace DAMS.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly DAMSDbContext _context;

        public TestDataBuilder(DAMSDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}