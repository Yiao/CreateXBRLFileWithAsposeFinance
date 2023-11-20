using System;
using Aspose.Finance.Xbrl;

namespace ASPOSEFINANCETEST
{
	public class XBRLGenerator
	{
        
        public XBRLGenerator()
		{

		}

        public static void Generate(string sourceXsd, string outputXbrlFile)
        {
            XbrlDocument document = new XbrlDocument();
            XbrlInstanceCollection xbrlInstances = document.XbrlInstances;
            XbrlInstance xbrlInstance = xbrlInstances[xbrlInstances.Add()];
            SchemaRefCollection schemaRefs = xbrlInstance.SchemaRefs;
            schemaRefs.Add(sourceXsd, "example", "http://example.com/xbrl/taxonomy");

            SchemaRef schema = schemaRefs[0];
            ContextPeriod contextPeriod = new ContextPeriod(DateTime.Parse("2020-01-01"), DateTime.Parse("2020-02-10"));
            ContextEntity contextEntity = new ContextEntity("exampleIdentifierScheme", "exampleIdentifier");
            Context context = new Context(contextPeriod, contextEntity);
            xbrlInstance.Contexts.Add(context);

            Unit unit = new Unit(UnitType.Measure);
            unit.MeasureQualifiedNames.Add(new QualifiedName("USD", "iso4217", "http://www.xbrl.org/2003/iso4217"));
            xbrlInstance.Units.Add(unit);

            Concept fixedAssetsConcept = schema.GetConceptByName("fixedAssets");
            if (fixedAssetsConcept != null)
            {
                Item item = new Item(fixedAssetsConcept);
                item.ContextRef = context;
                item.UnitRef = unit;
                item.Precision = 4;
                item.Value = "1444";
                xbrlInstance.Facts.Add(item);
            }
            document.Save(outputXbrlFile);
            Console.WriteLine("XbrlDocument executed successfully.");
        }
    }
}

