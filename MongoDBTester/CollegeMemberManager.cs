using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;
using MongoDBTester.Entities;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDBTester
{
    public partial class frmCollegeMemberManager : Form
    {
        //Will map the college member to their grades
        private Dictionary<string, Studentqualification[]> m_collegeMemberStudentQualificationMapping = default;
        //Will temporarily store removed context menu items
        private List<(int OriginalPosition, ToolStripItem MenuItem)> m_removedToolstripItems = new List<(int OriginalPosition, ToolStripItem MenuItem)>();

        public frmCollegeMemberManager() => InitializeComponent();

        //Initialise DB when the form loads
        private void frmCollegeMemberManager_Load(object sender, EventArgs e) => InitialiseDB();

        private void btnDisplayCollegeMembers_Click(object sender, EventArgs e)
        {
            try
            {   //Ensure previous items are removed
                m_collegeMemberStudentQualificationMapping = new Dictionary<string, Studentqualification[]>();
                dgvResult.Rows.Clear();
                Dictionary<string, string> collegeMemberTypeNameGuidMapping = new Dictionary<string, string>();
             
                //Ensure all stuff GUID's are replaced with 
                MongoDbConnector.MongoDatabase.GetCollection<CollegeMemberType>("CollegeMemberType").AsQueryable().ToList().ForEach((cmt) =>
                {
                    collegeMemberTypeNameGuidMapping.Add(cmt.Id.ToString(), cmt.Type);
                });

                //There must be college member types defined
                if (collegeMemberTypeNameGuidMapping.Count() == 0)
                    throw new Exception("Ensure College Member Types Are Present");

                //Get all college members
                List<CollegeMember> collegeMembersCollection = MongoDbConnector.MongoDatabase.GetCollection<CollegeMember>("CollegeMember").AsQueryable().ToList(); ;
                
                //Iterate through college members
                collegeMembersCollection.ForEach((collegeMember) =>
                {   //Try and retrieve the college member type
                    collegeMemberTypeNameGuidMapping.TryGetValue(collegeMember.Type, out string type);

                    //Display college member type in the display
                    string collegeMemberId = collegeMember.Id.ToString();
                    dgvResult.Rows.Add(new string[] { collegeMemberId, collegeMember.Name, collegeMember.Age.ToString(), type });
                    //Add a college member and qualification mapping
                    m_collegeMemberStudentQualificationMapping.Add(collegeMemberId, collegeMember.StudentQualification);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Issue Loading College Members");
            }
        }

        private void btnInitialiseMongoDB_Click(object sender, EventArgs e) => InitializeComponent();

        //Will be used to initialse a connection to the MongoDB database
        private void InitialiseDB()
        {
            try
            {
                //Initialise Database Connection
                MongoDbConnector.InitialiseDB();
                tsslStatus.Text = "Database Connection Success";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Issue Initialising Database");
                tsslStatus.Text = "Database Connection Failure";
            }
        }

        //Will close the 
        private void cmsCrudOptions_Paint(object sender, PaintEventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0)
                cmsCrudOptions.Close();
        }

        private void cmsCrudOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvResult.SelectedRows.Count != 0)
            {
                //Ensure the user will not be able to delete items when 
                if (dgvResult.SelectedRows.Count >= 2)
                {
                    if (cmsCrudOptions.Items.Count > 0)
                        RemoveMenutoolstripItem("Update");
                }
                else if (dgvResult.SelectedRows.Count == 1)
                {
                    if (m_removedToolstripItems.Count > 0)
                        ReplaceRemovedToolStripItems();
                }
            }
        }

        //Re-Insert all removed toolstrip menu items
        private void ReplaceRemovedToolStripItems()
        {
            for (int i = 0; i < m_removedToolstripItems.Count; i++)
            {   //Re-insert menu item in its original position
                (int OriginalPosition, ToolStripItem MenuItem) removedToolStripItemDetails = m_removedToolstripItems[i];
                cmsCrudOptions.Items.Insert(removedToolStripItemDetails.OriginalPosition, removedToolStripItemDetails.MenuItem);
            }
            //Remove un-required stored items
            m_removedToolstripItems.Clear();
        }


        //Will remove the desired menu item is more then one college member is selected
        private void RemoveMenutoolstripItem(string toolstripMenuItemText)
        {
            foreach (ToolStripItem item in cmsCrudOptions.Items)
            {
                if (string.Compare(item.Text, toolstripMenuItemText) == 0)
                {
                    //Store details of the removed menu item
                    int indexOfRemovedToolStripItem = cmsCrudOptions.Items.IndexOf(item);
                    m_removedToolstripItems.Add((indexOfRemovedToolStripItem, item));
                    cmsCrudOptions.Items.Remove(item);
                    break;
                }
            }
        }
    }
}
