using FastDB.Core;
using FastDB.Service;
using FastDB.Struct;
using Newtonsoft.Json.Linq;
using SQLST;
using SQLST.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.AOF
{
    public class AOFAdapter : IAOF
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeyValueSR _keyValue;
        public AOFAdapter(IUnitOfWork unitOfWork, IKeyValueSR KeyValue)
        {
            _unitOfWork = unitOfWork;
            _keyValue = KeyValue;
        }

        public void init(Fastdb sdb)
        {
            //var dbkv = _keyValue.Query("select top " + sdb.max + " * from KeyValueSTs order by newid()", new SqlParameter[] { }).ToList();
            var dbkv = _keyValue.Query("select * from KeyValueSTs", new SqlParameter[] { }).ToList();
            foreach (var item in dbkv)
            {
                switch (item.type)
                {
                    case 0:
                        sdb.keys.Add(item.key, new StringObject(item.value, FastDB.Core.ObjectType.fast_string, true, false, sdb.systime));
                        break;
                    case 1:
                        sdb.keys.Add(item.key, new FastDB.Struct.ListObject(item.value, FastDB.Core.ObjectType.fast_list, true, false, sdb.systime));
                        break;
                    case 2:
                        sdb.keys.Add(item.key, new FastDB.Struct.HashObject(item.value ,FastDB.Core.ObjectType.fast_hash,  true,  false, sdb.systime));
                        break;
                    default:
                        break;
                }
            }

            ///TODO
            /// sdb.auths
            /// sdb.users
        }

        public void stop(Fastdb sdb)
        {
            while (sdb.isrunning)
            {
            }
            sdb.isrunning = true;

            while (sdb.dirty.Count != 0)
            {
                var item = sdb.dirty.Dequeue();
                switch (item.operaType)
                {
                    case OperationType.Insert:
                        Insert(item.Key, item.Value);
                        break;
                    case OperationType.Update:
                        Update(item.Key, item.Value);
                        break;
                    case OperationType.Delete:
                        Delete(item.Key);
                        break;
                    case OperationType.None:
                        break;
                    default:
                        break;
                }
            }
        }

        public void sync(Fastdb sdb)
        {
            //阻塞操作
            sdb.isrunning = true;
            //同步未存储键
            while (sdb.dirty.Count != 0)
            {
                var item = sdb.dirty.Dequeue();
                switch (item.operaType)
                {
                    case OperationType.Insert:
                        Insert(item.Key, item.Value);
                        break;
                    case OperationType.Update:
                        Update(item.Key, item.Value);
                        break;
                    case OperationType.Delete:
                        Delete(item.Key);
                        break;
                    case OperationType.None:
                        break;
                    default:
                        break;
                }
            }

            //剔除冷键
            //if (sdb.keys.Count > sdb.max)
            //{
            //    sdb.keys = sdb.keys.OrderByDescending(p => p.Value.refcount).Take(sdb.max).ToDictionary(o => o.Key, o => o.Value);
            //}

            //同步时间
            sdb.lastsync = sdb.systime;
            sdb.isrunning = false;
        }

        public string Get(string key,ObjectType type)
        {
           var kv= _keyValue.Get(p => p.key == key&&p.type==(int)type);
            if (kv==null)
            {
                return null;
            }
            return kv.value;
        }

        public void Insert(string key, FastObject entity)
        {
            switch (entity.type)
            {
                case ObjectType.fast_string:
                    _keyValue.Insert(new SQLST.Model.Models.KeyValueST { type = (int)entity.type, key = key, isShare = entity.isShare, readOnly = entity.readOnly, value = (entity as StringObject).value.ToString() });
                    break;
                case ObjectType.fast_list:
                    _keyValue.Insert(new SQLST.Model.Models.KeyValueST { type = (int)entity.type, key = key, isShare = entity.isShare, readOnly = entity.readOnly, value = (entity as ListObject).value.ToString() });
                    break;
                case ObjectType.fast_hash:
                    _keyValue.Insert(new SQLST.Model.Models.KeyValueST { type = (int)entity.type, key = key, isShare = entity.isShare, readOnly = entity.readOnly, value = (entity as HashObject).value.ToString() });
                    break;
                case ObjectType.fast_tree:
                    _keyValue.Insert(new SQLST.Model.Models.KeyValueST { type = (int)entity.type, key = key, isShare = entity.isShare, readOnly = entity.readOnly, value = (entity as TreeObject ).value.ToString() });
                    break;
                default:
                    break;
            }
            _unitOfWork.Commit();
        }

        public void Update(string key, FastObject entity)
        {
            var tar = _keyValue.Get(p => p.key == key);
            switch (entity.type)
            {
                case ObjectType.fast_string:
                    tar.type = (int)entity.type;
                    tar.isShare = entity.isShare;
                    tar.readOnly = entity.readOnly;
                    tar.value = (entity as StringObject).value.ToString();
                    _keyValue.Update(tar);
                    break;
                case ObjectType.fast_list:
                    tar.type = (int)entity.type;
                    tar.isShare = entity.isShare;
                    tar.readOnly = entity.readOnly;
                    tar.value = (entity as ListObject).value.ToString();
                    _keyValue.Update(tar);
                    break;
                case ObjectType.fast_hash:
                    tar.type = (int)entity.type;
                    tar.isShare = entity.isShare;
                    tar.readOnly = entity.readOnly;
                    tar.value = (entity as HashObject).value.ToString();
                    _keyValue.Update(tar);
                    break;
                case ObjectType.fast_tree:
                    tar.type = (int)entity.type;
                    tar.isShare = entity.isShare;
                    tar.readOnly = entity.readOnly;
                    tar.value = (entity as TreeObject ).value.ToString();
                    _keyValue.Update(tar);
                    break;

                default:
                    break;
            }
            _unitOfWork.Commit();
        }

        public void Delete(string key)
        {
            var tar = _keyValue.Get(p => p.key == key);
            _keyValue.Delete(tar);
            _unitOfWork.Commit();
        }
    }
}
