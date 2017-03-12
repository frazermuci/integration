using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DataAccessDB : DataAccess
    {
        //private ActivAIDDB db;

        public DataAccessDB()
        {
            ;//db = new ActivAIDDB();
        }

        public Dictionary<int, List<string>> query(Query query)
        {
            Console.WriteLine(query.attributeList[0].value);
            //return db.getAllElements(query.attributeList.First().value);
            Dictionary<int, List<string>> dList = new Dictionary<int, List<string>>();
            if (query.attributeList[0].value == "NewUser.html")
            {
                dList[0] = new List<string>(new string[] { "Use the Login Manager to add a new user account for the application.&nbsp;" });
                dList[1] = new List<string>(new string[]{
                    "Click the new user button in the upper left corner or right-click on an empty line in the user list and select Add New User."
                    ,"The fields on the left side of the form will now be enabled.&nbsp; Enter the User ID for the new account.&nbsp; The User ID must be unique."
                    ,"Enter a description (optional).",
                    "Enter the password in the Password field.&nbsp; Check the Show Password as Text During Edit to show the real password characters instead of asterisks (*).",
                    "Re-enter the same password in the Confirm Password field.",
                    "Select the group the user is to be part of.",
                    "Click the Create User button to save the new user.&nbsp; If successful, the new user account will appear in the user list."});
                dList[2] = new List<string>(new string[] { "&nbsp;" });
                dList[3] = new List<string>(new string[] { "&nbsp;&nbsp;&nbsp; Login Manager | a user| Deleting a user" });
                dList[4] = new List<string>(new string[] { "&nbsp;" });
                dList[5] = new List<string>(new string[] { "Back to Top" });
                dList[6] = new List<string>(new string[] { "Astronics Test Systems Last updated on 3/1/07 by L. Anhalt" });
            }
            else if (query.attributeList[0].value == "EditUser.html")
            {
                dList[0] = new List<string>(new string[] { "Editing a user" });
                dList[1] = new List<string>(new string[]{
                    "Once &quot;Edit User&quot; is selected the fields on the left side that can be edited will be enabled.&nbsp; Fields that can be edited are &quot; Description & quot;, &quot; Password & quot;, and & quot; Member Of&quot;.&nbsp; The User ID cannot be edited."
                    ,"Click the &quot;Update User&quot; button when editing is complete to save updated user information.&nbsp; Fields will become disabled again after the changes have been successfully been changed."});
                dList[2] = new List<string>(new string[] { "&nbsp;" });
                dList[3] = new List<string>(new string[] { "See Also" });
                dList[4] = new List<string>(new string[] { "&nbsp;&nbsp;&nbsp; Login Manager | Adding a new user | Deleting a user" });
                dList[5] = new List<string>(new string[] { "&nbsp;" });
                dList[6] = new List<string>(new string[] { "Back to Top" });
                dList[7] = new List<string>(new string[] { "Astronics Test Systems" });
                dList[8] = new List<string>(new string[] { "Astronics Test Systems Last updated on 3/1/07 by L. Anhalt" });
            }
            else
            {
                dList[0] = new List<string>(new string[] { "Deleting a user" });
                dList[1] = new List<string>(new string[]{ "Use the Login Manager to delete a user from the application." });
                dList[2] = new List<string>(new string[] { "Click the delete user button in the upper left corner or right-click the User ID in the user list and select &quot; Delete User&quot;.",
                                                            "When &quot; Delete User&quot; is selected, a message box appears to confirmdeletion.& nbsp; Select & quot; Yes & quot; to delete user, select & quot; No & quot; to keep user in the application",
                                                            "The user will be permanently deleted once the &quot;Yes&quot; button is selected."});
                dList[3] = new List<string>(new string[] { "&nbsp;" });
                dList[4] = new List<string>(new string[] { "See Also" });
                dList[5] = new List<string>(new string[] { "&nbsp;&nbsp;&nbsp; Login Manager |Adding a new user | Editing a user" });
                dList[6] = new List<string>(new string[] { "&nbsp;" });
                dList[7] = new List<string>(new string[] { "Back to Top" });
                dList[8] = new List<string>(new string[] { "&nbsp;" });
                dList[9] = new List<string>(new string[] { "Astronics Test Systems Last updated on 3/1/07 by L. Anhalt" });
            }
            
            return dList;
        }
    }
}
