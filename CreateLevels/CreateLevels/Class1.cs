using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;




namespace CreateLevels
{

    [Transaction(TransactionMode.Manual)]

    class CmdCreateNewLevel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication app = commandData.Application;
            Document doc = app.ActiveUIDocument.Document;

            IEnumerable<ViewFamilyType> viewFamilyTypes =
                from elem in new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                let type = elem as ViewFamilyType
                where type.ViewFamily == ViewFamily.FloorPlan
                select type;


            //using (Transaction tx = new Transaction(doc))
            //{
            //    tx.Start("MyTransaction");
            double elevation = 20.0;
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Create New Level");
                try
                {
                    Level level = doc.Create.NewLevel(elevation);
                    if (null == level)

                        level.Name = "New Name";
                    //ElementId nid = level.Id;

                    ViewPlan.Create(doc, viewFamilyTypes.First().Id, level.Id);

                    tx.Commit();
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                {
                    return Result.Cancelled;
                }

            }
                return Result.Succeeded;
            }
        }
    
}

                 



        
         
            
        
 



       

   



     
                
 




    

        


       
        


            













    //    {
    //        UIApplication uiapp = commandData.Application;
    //        UIDocument uidoc = uiapp.ActiveUIDocument;
    //        Application app = uiapp.Application;
    //        Document doc = uidoc.Document;

//        using (Transaction trans = new Transaction(doc, "Level"))
//        {

//            trans.Start();


//            {
//                double elevation = 20.0;

//                Level level = doc.Create.NewLevel(elevation);
//                if (null == level)
//                {
//                    throw new Exception("Create a new level failed.");
//                }
//                // change the leve name
//                level.Name = "New Level";

//                return Result.Succeeded;

//                trans.Commit();
//            }
//        }

//    }
//}




