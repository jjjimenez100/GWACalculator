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

# Notes:
I wanted to learn a bit of C# since I've been seeing it as a "requirement" for most of the programming job hirings I've been seeing on my social networking sites. And because of this, I believe that learning a language would be a lot easier if you try to do a project with it. It's fun to tinker out with stuffs you don't really know yet. With this in mind, I focused on learning more on the concepts and implementations of the language, instead of making things look better and interactive. (Notice how I implemented my "settings" tab to be dependent on a single config text file, instead of just using the .settings feature of C#)

During the time I've spent creating this application (which was roughly around 30-40 mins a day, more or less) I was able to ponder on most of the language's concepts (including SQLite).
