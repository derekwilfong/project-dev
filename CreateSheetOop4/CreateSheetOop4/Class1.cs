using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace CreateSheetOop4
{
    [Transaction(TransactionMode.Manual)]

    public class CmdCreateSheetOop4 : IExternalCommand
    {


        //UIApplication app = commandData.Application;
        //Document doc = app.ActiveUIDocument.Document;
        public Document doc;
        

        Result IExternalCommand.Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
        

            doc = commandData.Application.ActiveUIDocument.Document;

            Result newSheet = CreateSheet();
            return newSheet;
 
            //throw new NotImplementedException();
        }







        public Result CreateSheet()
        {
            Titleblock symbolId = new Titleblock();
            symbolId.TitleblockId();

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("CreateSheetOop4");
                try
                {
                    ViewSheet viewSheet = ViewSheet.Create(doc, symbolId.TitleblockId());

                    tx.Commit();
                }
                catch (Autodesk.Revit.Exceptions.ApplicationException)
                {
                    return Result.Cancelled;
                }
            }
            return Result.Succeeded;
        }

    }
}
