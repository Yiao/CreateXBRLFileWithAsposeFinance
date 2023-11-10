using System;
using Aspose.Finance.Xbrl;

namespace ASPOSEFINANCETEST
{
	public class XBRLReader
	{
		public XBRLReader()
		{
		}
		public static XbrlInstance Load(string xbrlSourceFile) {
            XbrlDocument document = new XbrlDocument(xbrlSourceFile);
            XbrlInstanceCollection xbrlInstances = document.XbrlInstances;
            return xbrlInstances[0];
        }
    }
}

