﻿using MongoDB.Driver;
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
        public frmCollegeMemberManager() => InitializeComponent();

        private void frmCollegeMemberManager_Load(object sender, EventArgs e)
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

        private void btnDisplayCollegeMembers_Click(object sender, EventArgs e)
        {
            var collegeMembers = MongoDbConnector.MongoDatabase.GetCollection<CollegeMember>("CollegeMember");
            var collegeMembersCollection = collegeMembers.AsQueryable().ToList();

            var collegeMemberTypeNameGuidMapping = new Dictionary<string, string>();
            //Ensure all stuff guids are replaced with 
            MongoDbConnector.MongoDatabase.GetCollection<CollegeMemberType>("CollegeMemberType").AsQueryable().ToList().ForEach((cmt) =>
            {
                collegeMemberTypeNameGuidMapping.Add(cmt.Id.ToString(), cmt.Type);
            });

            foreach (CollegeMember collegeMember in collegeMembersCollection)
            {
                string type = collegeMemberTypeNameGuidMapping[collegeMember.Type];
            }
        }
    }
}
