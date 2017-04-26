# GWACalculator
A C# desktop application that automatically calculates for your current and overall GWA. 

# Features
1) Embedded SQLite database. No need for any database servers.
2) Allows user defined settings, such as custom number of years, custom name of course and etc., without impacting the main functions of the application.
3) Implements CRUD functionality for easier access and maintability.
4) Includes user logging, which allows user to track the changes or activities made with the application
5) Includes export to .docx functionality, exporting every data of user stored with the app to a microsoft word file. (.docx)

# Prerequisite(s)
1) Visual studio 2015 or newer (for opening the project folder and source codes)
2) .Net Framework 4.5.6

# Steps for installation
1) Run the .msi installer provided in the setup folder.
2) *IMPORTANT* Do not install the application on any SYSTEM DIRECTORIES. (To be specific, ProgramFiles(x86), and etc.) Recommended location for installation would be your documents folder.
3) After finishing the setup, run the application and configure your initial settings.

# Plugins used
1) Docx.net 
2) SQLite .Net Adapter
3) Entity Framework

# Programmer's note/s:
I wanted to learn a bit of C# since I've been seeing it as a "requirement" for most of the programming job hirings I've been seeing on my social networking sites. And because of this, I believe that learning a language would be a lot easier if you try to do a project with it. It's fun to tinker out with stuffs you don't really know yet. With this in mind, I focused on learning more on the concepts and implementations of the language, instead of making things look better and interactive. (Notice how I implemented my "settings" tab to be dependent on a single config text file, instead of just using the .settings feature of C#)

During the time I've spent creating this application (which was roughly around 30-40 mins a day, more or less) I was able to ponder on most of the language's concepts (including SQLite), implementations and syntax. Here are some of them:

1) You can choose to have static type binding or dynamic type binding with your variables. (Comparing it to other popular languages that only has one of these features) (e.g int x = 5 is static type binding while while dynamic z = 2 can be dynamically assigned to any values at compile time and run time.)
2) C# loops and java loops are almost the same. The only difference would be C#'s foreach loop syntax. C# also offers labels, breaks and continues.
3) Conditional statements are pretty much the same with other languages.
4) C# uses the "pascal" way of naming variables, but I've gone with the camel casing way since I like it better than pascal's way. (e.g. ThisIsAMethod)
5) Using the file.exists method may be a bit tricky especially if you are creating a file from the stream and the application was installed on a system directory. Windows automatically creates another directory where it stores every created file. It also shifts the application's source of directory from runtime, so you might find file.exists returning TRUE even if the file doesn't really exists on the application folder the app was installed. 
6) C# also provides us some useful data structures. Some of there are the Dictionary (which is like the "map" ds in java) and the ArrayList. 
7) Closing an SQLite connection at runtime WILL NOT TERMINATE THE STREAM ASSOCIATED WITH THE DATABASE. Hence, you won't be able to delete the file at runtime if you have established the connection. There is *no way* to close the stream. I have tried SQLite's close function, giving the databaseConnection a value of null and forcing the garbage collector of C# to collect the null object of SQLite connection. All of these didn't work.
8) Aside from that, SQLite's way of handling data back and forth, including the size of the database file, is really good. I would love to suggest it out applications who are expecting to have low-medium sized databases. 
9) When you're trying to deploy an app dependent with SQLite, do not forget that it has the x86 and x64 dlls. Without those, your app wouldn't be able to run because it's database functionality is purely dependent with those two dlls.
10) Docx.net, the plugin I used to programmatically create a word file, is really light but it is kind of outdated right now. I haven't seen a single post from the author of the plugin with the years 2016-2017. Most of them where posted on the year 2011-2013. Documentation's kind of outdated too, but I was able to work myself around by just reading the author's old posts about this plugin.  Aside from that, I'd give it a suggestion to those who would like to programmatically create .docx files because the syntax is really beginner friendly, you just have to understand how it really works by looking on the documentation (hopefully it's not with the outdated part) or by just looking at the author's posts.
Made by John Joshua Jimenez
