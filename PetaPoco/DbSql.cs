using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetaPoco
{
    public class DbSql : Sql
    {
        public class DbSqlJoinClause
        {
            private PetaPoco.Sql.SqlJoinClause _join;

            private DbSqlJoinClause(PetaPoco.Sql.SqlJoinClause join)
            {
                _join = join;
            }

            public static explicit operator DbSqlJoinClause(PetaPoco.Sql.SqlJoinClause join)
            {
                return new DbSqlJoinClause(join);
            }

            public DbSql On(string onClause, params object[] args)
            {
                return (DbSql)_join.On(onClause, args);
            }
        }


        Database _db;

        public DbSql(Database db)
            : base()
        {
            _db = db;
        }


        private Sql Wrapper { get { return (Sql)this; } }

        public new DbSql Append(Sql sql)
        {
            return (DbSql)Wrapper.Append(sql);
        }

        public new DbSql Append(string sql, params object[] args)
        {
            return (DbSql)Wrapper.Append(sql, args);
        }

        public new DbSql Where(string sql, params object[] args)
        {
            return (DbSql)Wrapper.Where(sql, args);
        }

        public new DbSql OrderBy(params object[] columns)
        {
            return (DbSql)Wrapper.OrderBy(columns);
        }

        public new DbSql Select(params object[] columns)
        {
            return (DbSql)Wrapper.Select(columns);
        }

        public new DbSql From(params object[] tables)
        {
            return (DbSql)Wrapper.From(tables);
        }

        public new DbSql GroupBy(params object[] columns)
        {
            return (DbSql)Wrapper.GroupBy(columns);
        }

        public new DbSql.DbSqlJoinClause InnerJoin(string table)
        {
            return (DbSql.DbSqlJoinClause)Wrapper.InnerJoin(table);
        }

        public new DbSql.DbSqlJoinClause LeftJoin(string table)
        {
            return (DbSql.DbSqlJoinClause)Wrapper.LeftJoin(table);
        }





        public int Delete<T>()
        {
            return _db.Delete<T>(this);
        }
        
        public int Execute()
        {
            return _db.Execute(this);
        }
        
        public T ExecuteScalar<T>()
        {
            return _db.ExecuteScalar<T>(this);
        }
        
        public List<T> Fetch<T>()
        {
            return _db.Fetch<T>(this);
        }
        
        public List<T> Fetch<T>(long page, long itemsPerPage)
        {
            return _db.Fetch<T>(page, itemsPerPage, this);
        }
        
        public List<TRet> Fetch<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb)
        {
            return _db.Fetch<T1, T2, T3, T4, TRet>(cb, this);
        }
        
        public List<T1> Fetch<T1, T2, T3, T4>()
        {
            return _db.Fetch<T1, T2, T3, T4>(this);
        }
        
        public List<TRet> Fetch<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb)
        {
            return _db.Fetch<T1, T2, T3, TRet>(cb, this);
        }
        
        public List<T1> Fetch<T1, T2, T3>()
        {
            return _db.Fetch<T1, T2, T3>(this);
        }
        
        public List<TRet> Fetch<T1, T2, TRet>(Func<T1, T2, TRet> cb)
        {
            return _db.Fetch<T1, T2, TRet>(cb, this);
        }
        
        public List<T1> Fetch<T1, T2>()
        {
            return _db.Fetch<T1, T2>(this);
        }
        
        public T First<T>()
        {
            return _db.First<T>(this);
        }
        
        public T FirstOrDefault<T>()
        {
            return _db.FirstOrDefault<T>(this);
        }
        
        public Page<T> Page<T>(long page, long itemsPerPage)
        {
            return _db.Page<T>(page, itemsPerPage, this);
        }
        
        public IEnumerable<T> Query<T>()
        {
            return _db.Query<T>(this);
        }
        
        public IEnumerable<TRet> Query<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb)
        {
            return _db.Query<T1, T2, T3, T4, TRet>(cb, this);
        }
        
        public IEnumerable<T1> Query<T1, T2, T3, T4>()
        {
            return _db.Query<T1, T2, T3, T4>(this);
        }
        
        public IEnumerable<TRet> Query<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb)
        {
            return _db.Query<T1, T2, T3, TRet>(cb, this);
        }
        
        public IEnumerable<T1> Query<T1, T2, T3>()
        {
            return _db.Query<T1, T2, T3>(this);
        }
        
        public IEnumerable<TRet> Query<T1, T2, TRet>(Func<T1, T2, TRet> cb)
        {
            return _db.Query<T1, T2, TRet>(cb, this);
        }
        
        public IEnumerable<T1> Query<T1, T2>()
        {
            return _db.Query<T1, T2>(this);
        }

        public T Single<T>()
        {
            return _db.Single<T>(this);
        }

        public T SingleOrDefault<T>()
        {
            return _db.SingleOrDefault<T>(this);
        }
        
        public List<T> SkipTake<T>(long skip, long take)
        {
            return _db.SkipTake<T>(skip, take, this);
        }

        public int Update<T>()
        {
            return _db.Update<T>(this);
        }
    }


    public static class DatabaseExtensions
    {
        public static DbSql Append(this Database db, Sql sql)
        {
            return (DbSql)new DbSql(db).Append(sql);
        }

        public static DbSql Append(this Database db, string sql, params object[] args)
        {
            return (DbSql)new DbSql(db).Append(sql, args);
        }

        public static DbSql Where(this Database db, string sql, params object[] args)
        {
            return (DbSql)new DbSql(db).Where(sql, args);
        }

        public static DbSql OrderBy(this Database db, params object[] columns)
        {
            return (DbSql)new DbSql(db).OrderBy(columns);
        }

        public static DbSql Select(this Database db, params object[] columns)
        {
            return (DbSql)new DbSql(db).Select(columns);
        }

        public static DbSql From(this Database db, params object[] tables)
        {
            return (DbSql)new DbSql(db).From(tables);
        }

        public static DbSql GroupBy(this Database db, params object[] columns)
        {
            return (DbSql)new DbSql(db).GroupBy(columns);
        }

        public static DbSql.DbSqlJoinClause InnerJoin(this Database db, string table) 
        {
            return (DbSql.DbSqlJoinClause)new DbSql(db).InnerJoin(table);
        }

        public static DbSql.DbSqlJoinClause LeftJoin(this Database db, string table) 
        {
            return (DbSql.DbSqlJoinClause)new DbSql(db).LeftJoin(table);
        }
    }
}
