# _Library_

#### _C# ASP.NET Core MVC and EF Core practice for Epicodus, 08.10.2020_

#### By _**Brittany Lindgren, Peter Grimm, and Ian Scott**_


## Description

_This Library program manages relationships between books, authors, copies of books, and users. This program allows users to add new books to the library database, manage connections with authors, and allows the user to know who has checked out a book, if the book is currently checked out, and if so when it is expected to return. This program further offers account managment, with individual users having unique accounts which manage their own checkout history._ 

## Specifications

| Behavior   |   Input   |  Output |  Met? (Y/N)  |
|----------|:-------------:|------:|-----------:|
|  |  |  |  |


## Stretch Goals
| Behavior   |   Input   |  Output |  Met? (Y/N)  |
|----------|:-------------:|------:|-----------:|


## User Stories  

* As a librarian, I want to create, read, update, delete, and list books in the catalog, so that we can keep track of our inventory.
* As a librarian, I want to search for a book by author or title, so that I can find a book when there are a lot of books in the library.
* As a librarian, I want to enter multiple authors for a book, so that I can include accurate information in my catalog. (Hint: make an authors table and a books table with a many-to-many relationship.)

Book                            Author              Copies
* Title                         * Name              * Many to one Copies - Books
* Publication Date              * DOB               * Copy ID
* Authors                       * Books             * Book Id
* BookId                        * AuthorId          * Book Obj
* Description                   * Bio Blurb         * 





* As a patron, I want to check a book out, so that I can take it home with me.
* As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)
* As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)
* As a patron, I want to know when a book I checked out is due, so that I know when to return it.

* As a librarian, I want to see a list of overdue books, so that I can call up the patron who checked them out and tell them to bring them back - OR ELSE!


## Setup/Installation Requirements

  1. Follow this [link to the project repository](PUT LINK HERE) on GitHub.  
  2. Click on the "Clone or download" button to copy the project link.     
  3. If you are comfortable with the command line, you can copy the project link and clone it through your command line with the command `git clone`. Otherwise, I recommend choosing "**Download ZIP**".     
   4. Once the ZIP file has finished downloading, you can right click on the file to view the zip folder in your downloads.     
  5. Right click on the project ZIP folder that you have just downloaded and choose the option "**Copy To...**", then choose the location where you would like to save this folder.      
  6. Navigate to the final location where you have chosen to save the project folder.      
  7. To view the code itself, right click, choose **open with...** and open using a text editor such as VS Code or Atom, etc.
  8. Once you are inside of your text editor, open the terminal. If you are in VS Code for example, this can be done by clicking on `Terminal` at the top of the editor and then selecting `New Terminal`. **You can navigate to different directories in the project by typing `cd DirectoryName` to go down into specific directories or `cd ..` to go back up one directory. 
  9. Navigate to the Library directory by typing `cd Library` in your terminal and hitting `enter`. Then type the command `dotnet restore`,`dotnet build`, then `dotnet run` into your terminal and hit enter. You should see files appear inside of your bin folder. The bin folder should appear greyed out. 
  10. Click on the link provided after you see `now listening on: ... ` appear in your terminal.


#### Additional Setup/Installation Notes:

* You will need to configure the MySQL Workbench database in order to run this project. See directions below.   
* Do not alter the bin/ or obj/ directories or any of the files in them.

#### Configure the MySQL Workbench Database:
* Install MySQL and MySQL Workbench first. During installation of MySQL you will be asked to create a password. This is important! Take note of your password. Once you have installed MySQL and MySQL Workbenck, start MySQL by entering `mysql -uroot -p+_yourpassword_` in the terminal. Example: password is `tomato`, enter `mysql -uroot ptomato`. If this doesn't work in your terminal, try using your computer's command line interface application. If you are successful, you will see a message in the terminal, ending with the line `mysql>`. Once you have succesfully completed these steps, follow the instructions below.
*  Open MySQL Workbench and double click on the grey box under the line `MySQL Connections` (this box should say `mamp` and have some text and numbers ending in `:3306`). This will launch the MySQL Workbench. You may be prompted to enter the same password that you used in the previous step (ex: `tomato`).  


#### Import Database to MySQL Workbench

To set up the database for this project, you can follow the steps below to import it into MySQL Workbench.

  * Open the Navigator, click on the `Administration` tab
  * Select `Data Import/Restore`
  * Select the option to `Import from Self-Contained File`
  * To the right, click on the `...` box to select the database file from this project (the file in the root directory ending in .sql)
  * Below the items from the last step, you'll see `Default Schema to be Imported To`, select  `New...` 
  * Enter the name of the database, in this case **`database_name`**
  * Select the `Import Progress` tab and click on the `Start Import` button.
  * Return to the Navigator window. Anywhere in that area, right click and select `refresh`
  * Your database should appear in the navigator window.    


#### Create a New Schema Query:
* You should see an icon in the upper left that looks like a little piece of paper with the letters `SQL` and a + sign. Hover over the icon and confirm that this is the 'create a new SQL tab for executing queries' icon. Once confirmed, double click the icon.
* Copy paste the code below into the Query tab.
* Then click 'execute' (this may appear as a lightening bolt icon).


##### SQL SCHEMA QUERY
```
CREATE DATABASE IF NOT EXISTS **_database_name_**; USE **_database_name_**;
DROP TABLE IF EXISTS `__efmigrationshistory`;

.
.
.

```

#### Code First with Migrations
You can also populate the Database from the VS Code terminal using Migrations.
*  Enter the following into the VS Code terminal `dotnet ef migrations add Initial` and hit Enter
* Now enter `dotnet ef datbase update` and hit Enter


#### Run the Application
* After you have completed setup and installation and configured the database, you can type the command `dotnet run` into your terminal.
* Once you see the message `now listening on: ... ` appear in your terminal, open your browser and type `localhost:5000` as the url. This should direct you to the main page of this project.


## Known Bugs

| Bug : Message |  Situation  | Resolved (Y/N) |  How was the issue resolved?  |
| ------- | ----- | ------ | ------- |
|  |  |  |  |


## Support and contact details

_Please feel free to contact the authors through GitHub (LINDGRENBA) with any feedback, questions or concerns._


## Technologies Used

* Entity Framework Core
* ASP.NET Core Identity
* ASP.NET Core MVC
* .NET Core 2.2
* MySQL & MySQL Workbench
* C#
* Razor
* Visual Studio Code
* Git Version Control
* GitHub


### License

*This site is licensed under the MIT license.*

Copyright (c) 2020 **_{Brittany Lindgren, Peter Grimm, and Ian Scott}_**