using System;
using System.Threading.Tasks;
using Abp.TestBase;
using DAMS.EntityFrameworkCore;
using DAMS.Tests.TestDatas;

namespace DAMS.Tests
{
    public class DAMSTestBase : AbpIntegratedTestBase<DAMSTestModule>
    {
        public DAMSTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<DAMSDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<DAMSDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<DAMSDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DAMSDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<DAMSDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<DAMSDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<DAMSDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DAMSDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
