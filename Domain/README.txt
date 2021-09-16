   __   _             __  ___     _ __  ___             ______        __ 
  / /  (_)_ _  ___   /  |/  /__ _(_) / / _ \___ _  __  /_  __/__ ___ / /_
 / /__/ /  ' \/ -_) / /|_/ / _ `/ / / / // / -_) |/ /   / / / -_|_-</ __/
/____/_/_/_/_/\__/ /_/  /_/\_,_/_/_/ /____/\__/|___/   /_/  \__/___/\__/ 
                                                                         

Welcome to the Lime Mail Dev Test README!

The purpose of this README is to inform you about a test to see how you solve problems 
and choose to implement a solution to a set of problems.

The Problem - View/Edit/Delete Mail messages in a web application


We would like you to create a Web Application with the features listed below

-A list view which lists first 100 mail messages (Name, ModifiedDate, IsSent)
	-In the view there should be a text box where you can enter a search string to search for mail messages 
	 Search the mail messages where the name contains the search term (Case insensitive)
	
	-In the list view there should be a button/link which navigates to the view details page for that mail message
	
-A details view which displays (Id, Name, ModifiedDate, IsSent) for a mail message
	-In the details view there should be a button which deletes the mail message and navigates back to the list view.
	 Deleteing stuff is a dangerous thing to do so a warning/confirmation dialog is needed before the delete is executed
	 The delete action should return (404 Not Found) if you're trying to delete a mail message which does not exist

Provided to you is an JSON file (mail-messages.json) which contains some mail message data. 
The mail-messages.json has the following structure

{ 
   "mailMessages":[ 
      { 
         "mailMessageId":"5540",
         "publicationId":"27",
         "name":"Pressmeddelande TUR 2014-03-18",
         "modifiedDate":"2014-03-18T10:06:01.893",
         "isSent":"1"
      },
	....
   ]
}

mailMessageId is a unique identifier for a mail message
publicationId is a foregein key (no publication data available)
name is the name of the mail message not unique
modifiedDate is a date
isSent is 1 when it's sent otherwise it's 0

Provided is also a class library , Lime.Domain.dll, (net standard 2.0) which contains 
 -An Entity class MailMessage (Id,Name,ModifiedDate,IsSent,PublicationId)
 -An interface IMailMessageRepository to handle retrieving/deleteing MailMessages


What we expect
- C#
- Reference the Lime.Domain class library
- You create and use an concrete implementation of the IMailMessageRespository found in the Lime.Domain.dll 
  for all the views/actions which uses the mail-messages.json as data source
- You can use any CSS framework of your choice to make it look pretty 
- You can use any JS framework of your choice 
- Dependency injection
- A test project with a test which tests the Delete action in the web application - when trying 
  to delete a mail message which does not exist and verifying that correct status code is returned
- If you like typescript -> use typescript (but not required at all)


Its OK to read all the mail-messages.json data into a static which contains the data while running - you dont need to update the json file it self.




