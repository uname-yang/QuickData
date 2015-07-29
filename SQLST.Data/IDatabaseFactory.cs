using SQLST.Model;
using System;

namespace SQLST.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        DatabaseContext Get();
    }
}