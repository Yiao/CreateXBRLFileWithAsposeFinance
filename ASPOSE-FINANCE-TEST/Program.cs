using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Finance.Xbrl;

namespace ASPOSEFINANCETEST
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Create xbrl from scach
            XBRLGenerator xBRLGenerator = new XBRLGenerator();
            //xBRLGenerator.Generate();


            string xbrlSourceFile = Path.GetFullPath(FileManager.GetTestFileDir() + "result.xml");

            // I do the validation before other actions
            Console.WriteLine("Validation Start");
            Validation.Xbrl(xbrlSourceFile);
            Console.WriteLine("Validation End");

            // I can load the xbrl file (.xml)
            XbrlInstance xbrlInstance = XBRLReader.Load(xbrlSourceFile);
            List<Fact> facts = xbrlInstance.Facts;
            List<Context> contexts = xbrlInstance.Contexts;
            List<Unit> units = xbrlInstance.Units;
            facts.ForEach(fact => Console.WriteLine(fact.Name));
            contexts.ForEach(context => Console.WriteLine(context.Period));
            units.ForEach(unit => Console.WriteLine(unit.MeasureQualifiedNames));


            // You can convert xbrl file(.xml) to excel file (.xlsx) or ixbrl file (.ixbrl)
            string excelTargetFile = Path.GetFullPath(FileManager.GetResultFileDir() + "result.xlsx");
            string ixbrlTargetFile = Path.GetFullPath(FileManager.GetResultFileDir() + "result.ixbrl");
            //Convertor.To(xbrlSourceFile, excelTargetFile, SaveFormat.XLSX);
            //Convertor.To(xbrlSourceFile, ixbrlTargetFile, SaveFormat.IXBRL);

            Console.ReadKey();
        }
    }
}
