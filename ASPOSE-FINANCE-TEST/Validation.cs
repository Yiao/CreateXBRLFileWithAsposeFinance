using System;
using Aspose.Finance.Xbrl;
using Aspose.Finance.Xbrl.Validator;
using System.Collections.Generic;

namespace ASPOSEFINANCETEST
{
	public class Validation
	{
		public Validation()
		{
		}


		public static List<ValidationError> Xbrl(String sourceXbrl)
		{
            XbrlDocument document = new XbrlDocument(sourceXbrl);
            XbrlInstanceCollection xbrlInstances = document.XbrlInstances;
            XbrlInstance xbrlInstance = xbrlInstances[0];

            xbrlInstance.Validate();

            List<ValidationError> validationErrors = new List<ValidationError>();
            if (xbrlInstance.ValidationErrors.Count > 0)
            {
                validationErrors = xbrlInstance.ValidationErrors;
                validationErrors.ForEach(valisationError => Console.WriteLine(valisationError.Message));
            }

            Console.WriteLine("ValidateXbrlInstance executed successfully.");
            return validationErrors;
        }
	}
}

