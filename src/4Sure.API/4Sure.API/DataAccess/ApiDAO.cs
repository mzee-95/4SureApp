using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.DataAccess
{
    public class ApiDAO : IDisposable
    {
        private DapperConnection connection;

        // Flag: Has Dispose already been called?
        bool disposed = false;

        public DapperConnection Connection { get { return connection; } }

        public ApiDAO(DapperConnection connection)
        {
            this.connection = connection;
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                this.connection?.Dispose();
            }

            disposed = true;
        }

        ~ApiDAO()
        {
            Dispose(false);
        }
    }
}
