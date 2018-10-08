using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;
using MongoDBTester.Entities;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDBTester.Forms;

namespace MongoDBTester
{   //This class will be responsible for allowing the user to display all college members and performing CRUD operations
    public partial class frmCollegeMemberManager : Form
    {
        #region Member Variables
        private Dictionary<string, CollegeMember> m_collegeMemberIdMappingCollection = default;
        private Dictionary<string, string> m_collegeMemberTypeNameGuidMapping = default;
        //Will temporarily store removed context menu items
        private List<(int OriginalPosition, ToolStripItem MenuItem)> m_removedToolstripItems = new List<(int OriginalPosition, ToolStripItem MenuItem)>();
        #endregion

        public frmCollegeMemberManager() => InitializeComponent();

        //Initialise DB when the form loads
        private void frmCollegeMemberManager_Load(object sender, EventArgs e) => InitialiseDB();

        #region Button Events
        private void btnDisplayCollegeMembers_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayCollegeMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Issue Loading College Members");
            }
        }

        private void btnInitialiseMongoDB_Click(object sender, EventArgs e) => InitialiseDB();

        private void btnClose_Click(object sender, EventArgs e) => Close();
        #endregion

        #region Other Click Events
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Collect the selected items index
                string selectedMembersId = dgvResult.SelectedRows[0].Cells["colMemberId"].Value.ToString();
                new frmCollegeMemberDetails(selectedMembersId, m_collegeMemberIdMappingCollection, m_collegeMemberTypeNameGuidMapping, new Action(DisplayCollegeMembers)).ShowDialog(this);
                DisplayStatusStripLabelMessage(tsslStatus, "College Member Details Updated");
            }
            catch (Exception ex)
            {
                DisplayStatusStripLabelMessage(tsslStatus, "Issue Updating College Member Details");
                MessageBox.Show(this, ex.Message, "Issue Updating College Member Details");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Collect the Id's of the selected college members to delete
                for (int i = 0; i < dgvResult.SelectedRows.Count; i++)
                {   //Get the selected college member Id
                    string collegeMemberId = dgvResult.SelectedRows[i].Cells["colMemberId"].Value.ToString();
                    MongoDbConnector.DeleteCollegeMember(m_collegeMemberIdMappingCollection[collegeMemberId]);
                    m_collegeMemberIdMappingCollection.Remove(collegeMemberId);
                }

                DisplayStatusStripLabelMessage(tsslStatus, "College Members Deleted");
            }
            catch (Exception ex)
            {
                DisplayStatusStripLabelMessage(tsslStatus, "Members Deletion Failure");
                MessageBox.Show(this, ex.Message, "Issue During Member Deletion");
            }

            DisplayCollegeMembers();
        }
        #endregion


        #region ContextMenuStripEvents
        //The relevant context menu items will be displayed depending the selected data grid view row count
        private void cmsCrudOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {   //There must be selected data grid view rows to continue processing
            if (dgvResult.SelectedRows.Count != 0)
            {
                //Ensure the user will not be able to update when two or more selected rows are present
                if (dgvResult.SelectedRows.Count >= 2)
                {
                    if (cmsCrudOptions.Items.Count > 0)
                        RemoveMenutoolstripItem("Update");
                }
                else if (dgvResult.SelectedRows.Count == 1)
                {   //Ensure the removed update context menu item is replaced post removal   
                    if (m_removedToolstripItems.Count > 0)
                        ReplaceRemovedToolStripItems();
                }
            }
        }

        //Will close the context menu item if no college members have been selected
        private void cmsCrudOptions_Paint(object sender, PaintEventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0)
                cmsCrudOptions.Close();
        }
        #endregion


        private void DisplayCollegeMembers()
        {   //Ensure the database has been initialized
            if (!MongoDbConnector.IsDatabaseInitialized)
                throw new Exception("Ensure Database Connection Initialization Has Taken Place");

            //Ensure previous items are removed
            m_collegeMemberIdMappingCollection = new Dictionary<string, CollegeMember>();
            dgvResult.Rows.Clear();
            m_collegeMemberTypeNameGuidMapping = new Dictionary<string, string>();

            //Ensure all stuff GUID's are replaced with 
            MongoDbConnector.GetCollegeMemberTypes().AsQueryable().ToList().ForEach((cmt) =>
            {
                m_collegeMemberTypeNameGuidMapping.Add(cmt.Id.ToString(), cmt.Type);
            });

            //There must be college member types defined
            if (m_collegeMemberTypeNameGuidMapping.Count() == 0)
                throw new Exception("Ensure College Member Types Are Present");

            //Get all college members
            List<CollegeMember> collegeMembersCollection = MongoDbConnector.GetCollegeMembers().AsQueryable().ToList();

            //Iterate through college members
            collegeMembersCollection.ForEach((collegeMember) =>
            {   //Try and retrieve the college member type
                m_collegeMemberTypeNameGuidMapping.TryGetValue(collegeMember.Type, out string type);

                //Display college member type in the display
                string collegeMemberId = collegeMember.Id.ToString();
                dgvResult.Rows.Add(new string[] { collegeMemberId, collegeMember.Name, collegeMember.Age.ToString(), type });
                //Add a college member and qualification mapping
                m_collegeMemberIdMappingCollection.Add(collegeMemberId, collegeMember);
            });
        }


        //Will be used to initialize a connection to the MongoDB database
        private void InitialiseDB()
        {
            try
            {
                //Initialize Database Connection
                MongoDbConnector.InitialiseDB();
                DisplayStatusStripLabelMessage(tsslStatus, "Database Connection Success");
            }
            catch (Exception ex)
            {
                DisplayStatusStripLabelMessage(tsslStatus, "Database Connection Failure");
                MessageBox.Show(this, ex.Message, "Issue Initializing Database");
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

        //Will remove the desired menu item when more then one college member is selected
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

        private void DisplayStatusStripLabelMessage(ToolStripStatusLabel control, string message) => control.Text = $"{DateTime.Now} - {message}";
    }
}
