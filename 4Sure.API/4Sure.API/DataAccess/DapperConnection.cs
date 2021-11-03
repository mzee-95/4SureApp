using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.DataAccess
{
    public class DapperConnection : IDisposable
    {
        private IDbConnection dbConnection;
        private IDbTransaction transaction;

        public DapperConnection(IDbConnection connection)
        {
            this.dbConnection = connection;
        }

        public void Open()
        {
            if (dbConnection != null)
            {
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
            }
            else
                throw new Exception("Connection is NULL"); ///TODO: throw proper exception
        }

        public void Close()
        {
            if (dbConnection != null)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction = null;
                }
                if (dbConnection.State != ConnectionState.Closed)
                    dbConnection.Close();
            }
            else
                throw new Exception("Connection is NULL"); ///TODO: throw proper exception
        }

        public IEnumerable<dynamic> Query(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.Query(sql, param, transaction: transaction);
            }
            else
                throw new Exception();
            //throw new Exceptions.InvalidConnectionStateException();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.Query<T>(sql, param, transaction: transaction);
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id")
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.Query(sql, map, param, splitOn: splitOn, transaction: transaction);
            }
            else
                throw new Exception();
            //throw new InvalidConnectionStateException();
        }

        public T QuerySingle<T>(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.QueryFirstOrDefault<T>(sql, param, transaction: transaction);
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public dynamic QuerySingle(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.QueryFirstOrDefault(sql, param, transaction: transaction);
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public int Execute(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.Execute(sql, param, transaction: transaction);
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public object ExecuteScalar(string sql, object param = null)
        {
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                return dbConnection.ExecuteScalar(sql, param, transaction: transaction);
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public bool InTransaction => transaction != null;

        public void BeginTransaction()
        {
            if (transaction != null)
                return;

            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                transaction = dbConnection.BeginTransaction();
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public void Rollback()
        {
            if (transaction == null)
                return;

            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                transaction.Rollback();
                transaction = null;
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        public void Commit()
        {
            if (transaction == null)
                return;

            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                transaction.Commit();
                transaction = null;
            }
            else
                throw new Exception();

            //throw new InvalidConnectionStateException();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                    dbConnection.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
