using System;
using System.Collections.Generic;
using Aspose.Finance.Xbrl;

namespace ASPOSEFINANCETEST
{
	public class XBRLGenerator
	{
        
        public XBRLGenerator()
		{

		}

        public void Generate()
        {
            XbrlDocument document = new XbrlDocument();
            XbrlInstanceCollection xbrlInstances = document.XbrlInstances;
            XbrlInstance xbrlInstance = xbrlInstances[xbrlInstances.Add()];
            SchemaRefCollection schemaRefs = xbrlInstance.SchemaRefs;
            schemaRefs.Add( @"HelloWorld.xsd", "example",
                "http://example.com/xbrl/yoyo");
            SchemaRef schema = schemaRefs[0];

            ContextPeriod contextPeriod = new ContextPeriod(DateTime.Parse("2020-01-01"),
                DateTime.Parse("2020-02-10"));
            ContextEntity contextEntity = new ContextEntity("exampleIdentifierScheme",
                "exampleIdentifier");

            Context context = new Context(contextPeriod, contextEntity);
            xbrlInstance.Contexts.Add(context);

            Unit unit = new Unit(UnitType.Measure);
            unit.MeasureQualifiedNames.Add(new QualifiedName("USD", "iso4217",
                "http://www.xbrl.org/2003/iso4217"));
            xbrlInstance.Units.Add(unit);


            List<string> listInfoToFill = new List<String>(){"Land","BuildingsNet",
    "FurnitureAndFixturesNet",
    "ComputerEquipmentNet",
    "OtherPropertyPlantAndEquipmentNet",
    "PropertyPlantAndEquipmentNet" };

            listInfoToFill.ForEach(info =>
            {
                Concept fixedAssetsConcept = schema.GetConceptByName(info);
                if (fixedAssetsConcept != null)
                {
                    Item item = new Item(fixedAssetsConcept);
                    item.ContextRef = context;
                    item.UnitRef = unit;
                    item.Precision = 4;
                    item.Value = "9999";
                    xbrlInstance.Facts.Add(item);
                }
            });
            document.Save(@"output\document5.xbrl");
        }
    }
}

