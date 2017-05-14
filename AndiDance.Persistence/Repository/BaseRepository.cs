using AndiDance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;


namespace AndiDance.Persistence.Repository
{
    public abstract class BaseRepository<T> where T : Entity
    {
        protected IDbConnection _db = new MySqlConnection("Server=localhost;Database=andidb;Uid=root;Pwd=1234");
        protected string _dbTableName;
        protected Dictionary<string, string> _fieldMap = new Dictionary<string, string>();
        protected bool _includeDeleted = false;
        public bool IncludeDeleted { get { return _includeDeleted; } set { _includeDeleted = value; } }

        /// <summary>
        /// 获取或计算其他属性值
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void GetOtherProperty(T entity)
        {

        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0}{1}", _dbTableName, _includeDeleted ? "" : " where isdeleted=false");
                var query = _db.Query<T>(sql);
                var result = query.ToList();
                foreach (var entity in result)
                {
                    GetOtherProperty(entity);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where id=@id", _dbTableName);
                var query = _db.Query<T>(sql, new { id });
                var result = query.First();
                GetOtherProperty(result);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">数据实体</param>
        public void Add(T entity)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var fields = string.Empty;
                var values = string.Empty;
                foreach (var fieldValue in _fieldMap)
                {
                    fields += fieldValue.Key + ",";
                    values += string.Format("@{0},", fieldValue.Value);
                }
                fields = fields.TrimEnd(',');
                values = values.TrimEnd(',');
                var sql = string.Format(@"insert into {0}({1}) values ({2});select @@IDENTITY", _dbTableName, fields, values);
                var query = _db.Query<int>(sql, entity);
                var result = query.Single();
                entity.Id = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">会员</param>
        public void Update(T entity)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var fields = string.Empty;
                foreach (var fieldValue in _fieldMap)
                {
                    fields += string.Format("{0}=@{1},", fieldValue.Key, fieldValue.Value);
                }
                fields = fields.TrimEnd(',');
                var sql = string.Format(@"update {0} set {1} where id=@Id", _dbTableName, fields);
                var query = _db.Execute(sql, entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 永久删除
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"delete from {0} where id = @Id", _dbTableName);
                var query = _db.Execute(sql, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
