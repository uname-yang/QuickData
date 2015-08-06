using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;

namespace QuickData.Controllers
{
    public class HashController : ApiController
    {
        private readonly IFastDB _fastdb;
        public HashController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }

        /// <summary>
        /// 获取整个字典
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [JsonQuery]
        public JObject Get(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Data = _fastdb.HashEntity.Get(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;
        }

        /// <summary>
        /// 新建字典
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Post(string key, [FromBody]object value)
        {
            _fastdb.HashEntity.Insert(key, value);
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(string key, [FromBody]object value)
        {
            _fastdb.HashEntity.Update(key, value);
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            _fastdb.HashEntity.Delete(key);
        }

        /// <summary>
        /// 返回给定键的值
        /// </summary>
        /// <param name="key">数据的Key</param>
        /// <param name="mkey">字典的key</param>
        /// <returns></returns>
        [JsonQuery]
        public JObject Get(string key, string mkey)
        {
            return _fastdb.HashEntity.Fetch(key,mkey);
        }

        /// <summary>
        /// 将给定的键值对添加到字典中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mkey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Post(string key, string mkey, [FromBody]object value)
        {
            return _fastdb.HashEntity.Add(key,mkey,value);
        }

        /// <summary>
        /// 将给定的键值对添加到字典中，如键已经存在，则新值替换原值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mkey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Put(string key, string mkey, [FromBody]object value)
        {
            return _fastdb.HashEntity.Replace(key,mkey,value);
        }

        /// <summary>
        /// 从字典中删除给定键所对应的键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mkey"></param>
        /// <returns></returns>
        public bool Delete(string key, string mkey)
        {
            return _fastdb.HashEntity.Remove(key,mkey);
        }
    }
}
