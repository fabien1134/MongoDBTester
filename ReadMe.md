This application is a demonstration how to use the MongoDB driver to create an application that can perform CRUD operations targeting a MongoDB database.
A list of students and staff will be read from the MongoDB database and displayed in a control.
The user will be able to delete, update , or create new staff. Any changes will be reflected in the database.

The database will have to be created and the connection string will have to be modified before use in your environment..

As of 06/10/2018, I came across an open .Net bug.link:'https://github.com/dotnet/standard/issues/567'
The work around was to removed the binding redirect entry from the app.config.
'<bindingRedirect oldVersion="0.0.0.0-4.0.2.0" newVersion="4.0.2.0"/>'