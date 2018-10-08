Instructions:
This applications language version is C# 7.3
Ensure your MongoDB server is running.
Ensure the string connection string and database name is changed to match your environment setup then build the project
When the application starts the CollectionMember and the CollectionMemberTypes collections should be created in the database if a the connection has been made
Insert At least one CollectionMember and the CollectionMemberTypes.

Structure of CollectionMember document
{
    "name" : "Sarah",
    "age" : 21,
    "type" : "5bb6a577536a06d83015d64a",
    "studentQualification" : [ 
        {
            "name" : "English",
            "grade" : "3rd"
        }, 
        {
            "name" : "Maths",
            "grade" : "2:1"
        }
    ]
}

Structure of CollectionMemberTypes
{
    "type" : "staff"
}

Additional Info:
-More then one college member can be deleted in one command
-College member details and qualifications can be amended at runtime
-Only one college member can be amended at any time
-College Members can have 0 or more qualifications

ToDo
-Will create a configuration GUI to alter the connection string and database name at runtime
-Re-factor code and add tests
------

This application is a demonstration how to use the MongoDB driver to create an application that can perform CRUD operations targeting a MongoDB database.
A list of students and staff will be read from the MongoDB database and displayed in a control.
The user will be able to delete, update , or create new staff. Any changes will be reflected in the database.

The database will have to be created and the connection string will have to be modified before use in your environment..

As of 06/10/2018, I came across an open .Net bug.link:'https://github.com/dotnet/standard/issues/567'
The work around was to removed the binding redirect entry from the app.config.
'<bindingRedirect oldVersion="0.0.0.0-4.0.2.0" newVersion="4.0.2.0"/>'