using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickData.Controllers;
using FastDB.Service;
using System.Web.Http;
using Autofac;
using System.Reflection;
using SQLST.Data;
using FastDB.Cache;
using FastDB.Pattern.Implementation;
using FastDB.AOF;
using FastDB.Cache.Repoistory;
using FastDB.Pattern;
using SQLST;
using System.Web.Mvc;
using System.Diagnostics;
using FastDB.Common;

namespace QuickData.Tests.Controllers
{
    [TestClass]
    public class Singletest
    {
       public static  IDatabaseFactory db = new DatabaseFactory();
        public static IUnitOfWork unit = new UnitOfWork(db);

        public static IKeyValueSR kv = new KeyValueSR(db);
        public static IAOF aof = new AOFAdapter(unit, kv);

        public static ISingleCache sc = new SingleCache();
        public static IListCache lc = new ListCache();
        public static IHashCache hc = new HashCache();
        public static ITreeCache tc = new TreeCache();
        public static IMemory mem = new Memory(sc, lc,hc,tc);

        public static IHashEntity he = new HashEntity(aof, mem);
        public static IListEntity le = new ListEntity(aof, mem);
        public static ISingleEntity se = new SingleEntity(aof, mem);
        public static ITreeEntity te = new TreeEntity(aof, mem);
        public static IFastDB fastdb = new FastDBService(he, le, se, te);
     //   public static DBStart st = new DBStart(aof, mem);
        [TestMethod]
        public void TestMethodPost()
        {
            Stopwatch sw = new Stopwatch();
           
            sw.Start();
            SingleController sct = new SingleController(fastdb);
            sct.Post("fff", new testmodel { i = 33, s = "yuyang" });
            for (int i = 0; i < 10000; i++)
            {
                sct.Post(i.ToString(),new testmodel { i=i,s="yuyang"});
            }
            sw.Stop();
            var tt = sw.Elapsed;
        }


        public void TestMethodGet()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SingleController sct = new SingleController(fastdb);
            for (int i = 0; i < 10000; i++)
            {
              var ss=  sct.Get(i.ToString());
            }
            sw.Stop();
            var tt = sw.Elapsed;
        }
    }

    public class testmodel
    {
        public int i { get; set; }
        public string s { get; set; }
    }
}
