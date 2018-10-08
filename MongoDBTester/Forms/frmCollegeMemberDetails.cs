using MongoDBTester.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBTester.Forms
{
    //This form will be responsible for allowing the user to update the selected college member details
    public partial class frmCollegeMemberDetails : Form
    {
        #region Member Variables
        private Dictionary<string, CollegeMember> m_collegeMemberIdMappingCollection = default;
        private string m_selectedCollegeMemberId = default;
        private Dictionary<string, string> m_collegeMemberTypeNameGuidMappingCollection = default;
        private CollegeMember m_selectedCollegeMember = default;
        #endregion

        #region Delegates
        private Action m_displayCollegeMembers = default;
        #endregion

        public frmCollegeMemberDetails(string collegeMemberId, Dictionary<string, CollegeMember> collegeMemberIdMappingCollection, Dictionary<string, string> collegeMemberTypeNameGuidMapping, Action displayCollegeMembers)
        {
            InitializeComponent();
            m_collegeMemberIdMappingCollection = collegeMemberIdMappingCollection;
            m_selectedCollegeMemberId = collegeMemberId;
            m_collegeMemberTypeNameGuidMappingCollection = collegeMemberTypeNameGuidMapping;
            m_displayCollegeMembers = displayCollegeMembers;
        }

        //The selected member's details will be updated when the form is loaded
        private void frmCollegeMemberDetails_Load(object sender, EventArgs e)
        {
            try
            {
                m_selectedCollegeMember = m_collegeMemberIdMappingCollection[m_selectedCollegeMemberId];
                //Load college member details
                dgvCollegeMember.Rows.Add(new string[] { m_selectedCollegeMemberId, m_selectedCollegeMember.Name, m_selectedCollegeMember.Age.ToString(), m_collegeMemberTypeNameGuidMappingCollection[m_selectedCollegeMember.Type] });

                //Load Qualifications
                if (m_selectedCollegeMember.StudentQualification.Length >= 1)
                {
                    foreach (Studentqualification studentqualification in m_selectedCollegeMember.StudentQualification)
                    {
                        dgvQualifications.Rows.Add(new string[] { studentqualification.Name, studentqualification.Grade });
                    }
                }

                DisplayStatusStripLabelMessage(tsslStatus, "College Member Loaded");
            }
            catch (Exception ex)
            {
                DisplayStatusStripLabelMessage(tsslStatus, "Issue During Form Loading");
                MessageBox.Show(this, ex.Message, "Issue While Loading Form");
               
            }
        }


        #region Button Events
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Ensure all cells have values input
                ValidateCellsNotEmpty();

                //Ensure a valid number is input in the age cell
                if (!int.TryParse(dgvCollegeMember.Rows[0].Cells["colAge"].Value.ToString(), out int parsedAge) || parsedAge < 1)
                    throw new Exception("Ensure A Valid Number Is Entered In The Age Cell");

                //Ensure the college member type has been defined in the database
                string collegeMemberType = dgvCollegeMember.Rows[0].Cells["colType"].Value.ToString();

                //Ensure the type is a valid selection
                if (!m_collegeMemberTypeNameGuidMappingCollection.ContainsValue(collegeMemberType))
                    throw new Exception("Ensure The Type Is A Valid College Member Type");

                //Get the key of the selected college member type
                collegeMemberType = GetCollegeMeberTypeMappedKey(collegeMemberType);

                //Overwrite the college members properties
                m_selectedCollegeMember.Type = collegeMemberType;
                m_selectedCollegeMember.Name = dgvCollegeMember.Rows[0].Cells["colMemberName"].Value.ToString();
                m_selectedCollegeMember.Age = parsedAge;

                //Store Updated Grades
                m_selectedCollegeMember.StudentQualification = ReturnUpdatedStudentQualifications();

                //Attempt to update the college member to the database
                MongoDbConnector.UpdateCollegeMember(m_selectedCollegeMember);

                //Ensure the college member data grid view is updated with the document new changes
                m_displayCollegeMembers?.Invoke();

                //Overwrite the previous stored college member
                m_collegeMemberIdMappingCollection[m_selectedCollegeMemberId] = m_selectedCollegeMember;
                DisplayStatusStripLabelMessage(tsslStatus,"College Member Update Success");
            }
            catch (Exception ex)
            {
                const string errorMessage = "Issue While Updating Details";
                DisplayStatusStripLabelMessage(tsslStatus, errorMessage);
                MessageBox.Show(this, ex.Message, errorMessage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
        #endregion


        private void DisplayStatusStripLabelMessage(ToolStripStatusLabel control,string message) => control.Text = $"{DateTime.Now} - {message}";

        //Ensure the user has input data in all cells
        private void ValidateCellsNotEmpty()
        {
            //Ensure all cells have values input
            EnsureAllCellsAreFilled(dgvCollegeMember.Rows[0].Cells);

            for (int i = 0; i < dgvQualifications.Rows.Count; i++)
            {   //Only validate cells that have been committed
                if (!dgvQualifications.Rows[i].IsNewRow)
                    EnsureAllCellsAreFilled(dgvQualifications.Rows[i].Cells);
            }
        }

        //Will return the key of the member type value
        private string GetCollegeMeberTypeMappedKey(string collegeMemberType)
        {
            //Get the key of the selected college member type
            for (int i = 0; i < m_collegeMemberTypeNameGuidMappingCollection.Count; i++)
            {
                KeyValuePair<string, string> collegeMemberTypeNameGuidMapping = m_collegeMemberTypeNameGuidMappingCollection.ElementAt(i);
                if (string.Compare(collegeMemberTypeNameGuidMapping.Value, collegeMemberType) == 0)
                {   //Replace the value with its mapped key
                    collegeMemberType = collegeMemberTypeNameGuidMapping.Key;
                }
            }

            return collegeMemberType;
        }

        //Retrieve the student qualification collection
        private Studentqualification[] ReturnUpdatedStudentQualifications()
        {
            //Will store the updated student qualifications, will not include the new row in the count
            Studentqualification[] studentqualifications = new Studentqualification[dgvQualifications.Rows.Count - 1];

            //Store Updated Grades
            for (int i = 0; i < dgvQualifications.Rows.Count; i++)
            {   //Only validate cells that have been committed
                if (!dgvQualifications.Rows[i].IsNewRow)
                {
                    studentqualifications[i] = new Studentqualification()
                    {
                        Name = dgvQualifications.Rows[i].Cells["colName"].Value.ToString(),
                        Grade = dgvQualifications.Rows[i].Cells["colGrade"].Value.ToString()
                    };
                }
            }

            return studentqualifications;
        }

        //Ensure cells in the data grid view row contain values
        private void EnsureAllCellsAreFilled(DataGridViewCellCollection cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Value == null)
                    throw new Exception("Ensure All College Member Cells Are Filled");
            }
        }
    }
}
