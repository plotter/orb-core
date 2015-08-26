using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using orb_core;

namespace OrbCoreUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            var jsonResult = OrbCore.toJson(dataSet);

            Console.WriteLine(jsonResult);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";
            var table = new DataTable();
            var idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            var itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                var newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            var ctable = new DataTable();
            var cidColumn = new DataColumn("id", typeof(int));
            cidColumn.AutoIncrement = true;
            var cpidColumn = new DataColumn("pid", typeof(int));
            var citemColumn = new DataColumn("item");
            ctable.Columns.Add(cidColumn);
            ctable.Columns.Add(cpidColumn);
            ctable.Columns.Add(citemColumn);
            dataSet.Tables.Add(ctable);

            var relation = dataSet.Relations.Add(idColumn, cpidColumn);
            relation.Nested = true;

            for (int i = 0; i < 4; i++)
            {
                var newRow = ctable.NewRow();
                newRow["item"] = "item " + i;
                newRow["pid"] = i % 2;
                ctable.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            var jsonResult = OrbCore.toJson(dataSet);

            Console.WriteLine(jsonResult);
        }
    }
}
