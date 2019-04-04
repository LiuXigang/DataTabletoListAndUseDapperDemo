using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using Dapper;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RunSqlAndDTtoList
{
    public class Program
    {
        public static string Constr = "DataBaseStr";
        public static string Path = AppDomain.CurrentDomain.BaseDirectory;
        public static void Main(string[] args)
        {
            //TestDataTableToList();
            //TestRunSql()
            Console.ReadKey();
        }
        public static void TestDataTableToList()
        {
            var table = new DataTable();
            var count = 1000000;

            using (IDbConnection connection = new SqlConnection(Constr))
            {
                var sql = $"SELECT * FROM mix_brand_product limit 0,{count}";
                var reader = connection.ExecuteReader(sql);
                table.Load(reader, LoadOption.PreserveChanges, FillErrorHandler);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = table.ToListByEmit<MixBrandProduct>();
            sw.Stop();
            Console.WriteLine($"Emit:{sw.ElapsedMilliseconds}毫秒");
            sw.Restart();
            var data2 = table.ToListByReflect<MixBrandProduct>();
            sw.Stop();
            Console.WriteLine($"Reflect:{sw.ElapsedMilliseconds}毫秒");
        }
        public static void TestRunSql()
        {
            var taskFactory = new TaskFactory();
            for (var i = 0; i < 5; i++)
            {
                taskFactory.StartNew(() => RunSql("v_hgp_delivery_detail_query"));
                taskFactory.StartNew(() => RunSql("v_price_adjust_category2"));
                taskFactory.StartNew(() => RunSql("v_my_brand_product_by_price"));
                taskFactory.StartNew(() => RunSql("v_hgp_order"));
                taskFactory.StartNew(() => RunSql("v_hgp_delivery_head"));
                taskFactory.StartNew(() => RunSql("v_delivery"));
                taskFactory.StartNew(() => RunSql("v_stock_location"));
            }
        }
        public static void FillErrorHandler(object sender, FillErrorEventArgs e)
        {
            if (e.Errors.GetType() == typeof(NullReferenceException) || e.Errors.GetType() == typeof(FormatException))
            {
                Console.WriteLine(e.Values[0]);
            }
            e.Continue = true;
        }
        public static void RunSql(string fileName)
        {
            var stopwatch = Stopwatch.StartNew();
            using (IDbConnection connection = new SqlConnection(Constr))
            {
                try
                {
                    var sqlStr = File.ReadAllText(Path + fileName + ".sql");
                    connection.Query(sqlStr).AsList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{fileName}({Thread.CurrentThread.ManagedThreadId})：{e.Message}");
                    return;
                }
                finally
                {
                    connection.Close();
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"{fileName}({Thread.CurrentThread.ManagedThreadId})：{stopwatch.ElapsedMilliseconds}(毫秒)");
        }
    }

}
