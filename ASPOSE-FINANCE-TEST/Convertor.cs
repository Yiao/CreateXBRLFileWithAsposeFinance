using System;
using Aspose.Finance.Xbrl;

namespace ASPOSEFINANCETEST
{
	public class Convertor
	{
		public Convertor()
		{
		}

		public static void To(String sourceXbrl, String target,SaveFormat saveFormat)
		{
			XbrlDocument document = new XbrlDocument(sourceXbrl);
            SaveOptions saveOptions = new SaveOptions();
			saveOptions.SaveFormat = saveFormat;
            document.Save(target, saveOptions);
		}
	}
}

