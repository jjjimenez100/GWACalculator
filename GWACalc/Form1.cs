using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;

namespace GWACalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            totalNumOfUnits = 0;
            subjectWeights = new ArrayList();
            if (!File.Exists(configPath))
            {
                createDefaultConfigFile();
            }
            currentConfig = new StreamReader(configPath);
            if (!File.Exists(userLogsPath))
            {
                createDefaultLogFile();
            }
            if (!File.Exists(aboutPath))
            {
                createDefaultChangelogs(aboutPath);
            }
            InitializeComponent();
            initializeDynamicComponents();
            if (!File.Exists(databaseName))
            {
                createDatabaseFile();
                initializeDatabase(false);

            }
            else
            {
                initializeDatabase(verifyMinimumSettings());
            }
            fetchData();
            totalGWA();
            GWA();
            writeToUserLogs("Application started.");
            currentConfig.Close();

            //String change = "";
            //writeToChangelogs(change);
        }
        //main method called enclosed in a try catch block to perform write tasks on text files
        private bool writeToTextFile(String filePath, params String[] texts)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath, true);
                foreach (String text in texts)
                {
                    writer.WriteLine(text);
                }
                writer.Close();
                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.StackTrace);
                return false;
            }
        }
        //creates default config file if it config file does not exists
        private void createDefaultConfigFile()
        {
            String info = "Changing the values of: numOfYears, numOfSummerTerms and numOfSemsPerYr will delete the exisiting database embedded in the application.";
            String minimumRequirements = "Minimum requirement of 2 years per course, and 2 semesters per year.";
            String example = "Ex: doNotEdit: valueThatCanBeEditted";
            String lineSeperator = "---------------------------------------------";
            String[] defaultDocConfiguration = { "name: Joshua Jimenez", "university: Holy Angel University",
                                                 "yearLevel: 3rd Year", "schoolAddress: mining",
                                                 "generatedDocName: gwaCalc_genReport.docx" };
            String[] defaultConfiguration = { "course: Computer Science",
                "numOfYears: 2", "numOfSummerTerms: 0", "numOfSemsPerYr: 2", "maxNumOfUnits: 3",
                "possible grades: " };
            writeToTextFile(configPath, info, minimumRequirements, example, lineSeperator);
            foreach (String setting in defaultDocConfiguration)
            {
                writeToTextFile(configPath, setting);
            }
            foreach (String setting in defaultConfiguration)
            {
                writeToTextFile(configPath, setting);
            }
            for (double grade = 1; grade != 3.25; grade += 0.25)
            {
                writeToTextFile(configPath, grade.ToString()); //default grading system
            }
            writeToTextFile(configPath, "5");
        }
        //instantiates connection to the sqlite database if it exists, or creates sqlite database if it does not exist
        //start - chain call to create sqlite database if it does not exist
        private void initializeDatabase(bool dbExists)
        {
            initializeDatabaseConnection();

            int summerCount = numOfTotalPages - numOfPageSemsPerYr;
            if (!dbExists)
            {
                int yearCount = 1, semCount = 1;
                for (int counter = 1; counter <= numOfPageSemsPerYr; counter++)
                {
                    createTable("tblYr" + yearCount + "Sem" + semCount + " (");
                    if (semCount == numOfSemsPerYr)
                    {
                        yearCount++;
                        semCount = 1;
                        continue;
                    }
                    semCount++;
                }
                for (int counter = 1; counter <= summerCount; counter++)
                {
                    createTable("tblSummerTerm" + counter + " (");
                }
                String getQuery = "Select Count(*) FROM sqlite_master where type='table'";
                SQLiteCommand getNumOfTables = new SQLiteCommand(getQuery, dbConnection);
                object x = getNumOfTables.ExecuteScalar();
                Properties.Settings.Default.numOfTables = int.Parse(x.ToString());
                Properties.Settings.Default.Save();
            }
        }
        //creates the database file
        private void createDatabaseFile()
        {
            SQLiteConnection.CreateFile(databaseName);
        }
        //deletes the specificed database file
        private void deleteDatabaseFile()
        {
            File.Delete(databaseName);
        }
        //initializes connection string to the db file
        private void initializeDatabaseConnection()
        {
            dbConnection = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;");
            dbConnection.Open();
        }
        private void createTable(String tblName)
        {
            String createQuery = "create table ";
            for (int index = 0; index < columnNames.Length; index++)
            {
                if (index != columnNames.Length - 1)
                {
                    tblName += columnNames[index] + " text NOT NULL, ";
                } //form the create table query for each column name specified
                else
                {
                    tblName += columnNames[index] + " text NOT NULL";
                }
            }
            tblName += ")";
            tblName = createQuery + tblName;
            SQLiteCommand create = new SQLiteCommand(tblName, dbConnection);
            create.ExecuteNonQuery();
        }
        //end of chain call

        //creates default user log file if it does not exist
        private void createDefaultLogFile()
        {
            String header = "-GWA Calculator User Logs-";
            DateTime currentTime = DateTime.Now;
            String dateOfCreation = "Created at: " + currentTime.ToString();
            writeToTextFile(userLogsPath, header, dateOfCreation);
        }

        //enables the program to write on the log file
        private void writeToUserLogs(String action)
        {
            StreamWriter userLogs = new StreamWriter(userLogsPath, true);
            DateTime currentTime = DateTime.Now;
            userLogs.WriteLine(currentTime.ToString() + ": " + action);
            userLogs.Close();
        }

        //creates default changelogs if it does not exist
        private void createDefaultChangelogs(String aboutPath)
        {
            String header = "A C# Program to compute your current/overall GWA.";
            String creator = "jjjimenez";
            String subheading = "Changelogs";
            writeToTextFile(aboutPath, header, creator, "", subheading);
        }
        //enables the program to write on the changelogs
        private void writeToChangelogs(String aboutPath, params String[] changes)
        {
            foreach (String change in changes)
            {
                DateTime currentTime = DateTime.Now;
                writeToTextFile(aboutPath, currentTime + ": " + change);
            }
        }

        //initializes the dynamic components of this program (datagrid views, combo boxes, etc.)
        //start of chain call
        private void initializeDynamicComponents()
        {
            String[] stringSettings = { "name: ", "university: ", "yearLevel: ", "schoolAddress: ",
                                        "generatedDocName: ", "course: "};
            String[] numericSettings = {"numOfYears: ", "numOfSummerTerms: "
                , "numOfSemsPerYr: ", "maxNumOfUnits: "};
            String[] columnHeaderText = { "Subject", "Grade", "Units" };
            configLineIterator(4); //skip the warning part.

            Dictionary<String, String> stringSettingsValues = setStringSettingValues(stringSettings);
            Dictionary<String, int> numericSettingsValues = setNumericSettingValues(numericSettings);

            verifyMinimumSettings(numericSettingsValues["numOfSemsPerYr: "], numericSettingsValues["numOfYears: "]);

            numOfSemsPerYr = numericSettingsValues["numOfSemsPerYr: "];
            configLineIterator(1); //skip possible grades

            setComboBoxes(numericSettingsValues["maxNumOfUnits: "]);

            numOfPageSemsPerYr = numericSettingsValues["numOfYears: "] * numericSettingsValues["numOfSemsPerYr: "];
            numOfTotalPages = numOfPageSemsPerYr + numericSettingsValues["numOfSummerTerms: "];

            setDataGridView(setTabPages(numOfPageSemsPerYr, numOfTotalPages), numOfTotalPages, columnNames, columnHeaderText);

            lblCourse.Text = stringSettingsValues["course: "];

            docUserName = stringSettingsValues["name: "];
            docUniversity = stringSettingsValues["university: "];
            docYearLevel = stringSettingsValues["yearLevel: "];
            docSchoolAddr = stringSettingsValues["schoolAddress: "];
            docName = stringSettingsValues["generatedDocName: "];

            yearPane.SelectedIndexChanged += new EventHandler(changeTabs);
        }
        //moves the stream reader iterator by the specified # of characters
        private void configCharIterator(int numOfChars)
        {
            for (int counter = 1; counter <= numOfChars; counter++)
            {
                currentConfig.Read();
            }
        }
        //moves the stream reader iterator by the specified # of lines
        private void configLineIterator(int numOfLines)
        {
            for (int counter = 1; counter <= numOfLines; counter++)
            {
                currentConfig.ReadLine();
            }
        }
        //extracts the string setting values from the config.ini
        private Dictionary<String, String> setStringSettingValues(String[] stringSettings)
        {
            Dictionary<String, String> stringSettingsValues = new Dictionary<String, String>();
            for (int index = 0; index < stringSettings.Length; index++)
            {
                configCharIterator(stringSettings[index].Length);
                stringSettingsValues.Add(stringSettings[index], currentConfig.ReadLine());
            }
            return stringSettingsValues;
        }
        //extracts the numeric setting values from the config.ini
        private Dictionary<String, int> setNumericSettingValues(String[] numericSettings)
        {
            Dictionary<String, int> numericSettingsValues = new Dictionary<String, int>();
            for (int index = 0; index < numericSettings.Length; index++)
            {
                configCharIterator(numericSettings[index].Length);
                String holder = currentConfig.ReadLine();
                if (isDigit(holder))
                {
                    numericSettingsValues.Add(numericSettings[index], Convert.ToInt16(holder));
                }
                else
                {
                    halt("Invalid setting: " + holder + ". ");
                }
            }
            return numericSettingsValues;
        }
        //checks if the numericSetting is purely numeric
        private bool isDigit(String numericSetting)
        {
            double convertedNumericSetting;
            return double.TryParse(numericSetting, out convertedNumericSetting);
        }
        //checks if settings meet the required minimum values
        private bool verifyMinimumSettings(int holderNumOfSemsPerYr, int numOfYears)
        {
            if (holderNumOfSemsPerYr < 2 || numOfYears < 2)
            {
                halt("Number of years and number of sems per year should not be lower than 2. ");
            }
            return true;
        }

        private bool verifyMinimumSettings()
        {
            String infoPrompt = "Embedded database was emptied because the application detected changes in the config file.";
            if (Properties.Settings.Default.numOfTables != 0 && Properties.Settings.Default.numOfTables != numOfTotalPages)
            {
                MessageBox.Show(infoPrompt, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deleteDatabaseFile();
                return false;
            }
            return true;
        }
        //prompts user before halting the program
        private void halt(String message)
        {
            if (MessageBox.Show(message + warning, "WARNING",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
            {
                Process.Start(configPath);
                halt();
            }
        }
        //halts the program
        private void halt()
        {
            Environment.Exit(0);
        }
        //sets the options for the combo boxes depending on the values derived from the config.ini file
        private void setComboBoxes(int maxNumOfUnits)
        {
            while (!currentConfig.EndOfStream)//get all possible grades
            {
                comboGrade.Items.Add(Convert.ToDouble(currentConfig.ReadLine()));
            }

            for (int counter = 1; counter <= maxNumOfUnits; counter++)
            {
                comboUnits.Items.Add(counter);
            }
            comboGrade.SelectedIndex = 0;
            comboUnits.SelectedIndex = 0;
        }
        //initializes tabpages
        private TabPage[] setTabPages(int numOfPageSemsPerYr, int numOfTotalPages)
        {
            int semCount = 1, yearCount = 1, pageIndex = 0;
            TabPage[] pageYearsAndSem = new TabPage[numOfTotalPages];
            for (; pageIndex < numOfPageSemsPerYr; pageIndex++)
            {
                pageYearsAndSem[pageIndex] = new TabPage();              //lagay yung control pati per sem 
                pageYearsAndSem[pageIndex].Text = "Year " + (yearCount) + " Sem " + (semCount);
                if (semCount == numOfSemsPerYr)
                {
                    yearCount++;
                    semCount = 1;
                    continue;
                }
                semCount++;
            }

            for (int summerCount = 1; pageIndex < numOfTotalPages; pageIndex++, summerCount++)
            {
                pageYearsAndSem[pageIndex] = new TabPage();
                pageYearsAndSem[pageIndex].Text = "Summer Term " + (summerCount);
            }
            yearPane.Controls.AddRange(pageYearsAndSem);
            return pageYearsAndSem;
        }
        //initializes tables/datagridview
        private void setDataGridView(TabPage[] pageYearsAndSem, int numOfTotalpages, String[] columnNames, String[] columnHeaderText)
        {
            tables = new DataGridView[numOfTotalpages];
            int yearCount = 1, semCount = 1, summerCount = 1;
            for (int index = 0; index < numOfTotalpages; index++)
            {
                tables[index] = new DataGridView();
                tables[index].AutoGenerateColumns = true;
                for (int indexNames = 0; indexNames < columnNames.Length; indexNames++)
                {   //for each column name, add them to each tables 
                    tables[index].Columns.Add(columnNames[indexNames], columnHeaderText[indexNames]);
                } //set specific table properties
                tables[index].Size = new Size(274, 254);
                tables[index].RowHeadersVisible = false;
                tables[index].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                tables[index].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                tables[index].AllowUserToResizeColumns = false;
                tables[index].AllowUserToResizeRows = false;
                tables[index].AllowUserToAddRows = false;
                tables[index].SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tables[index].MultiSelect = false;
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                { //for each column, set property of column headers to be aligned at the center
                    DataGridViewColumn column = tables[index].Columns[columnIndex];
                    column.Width = 90;
                    column.ReadOnly = true;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (index > numOfPageSemsPerYr - 1) //name tables as "tblSummerTermX"
                {
                    tables[index].Name = "tblSummerTerm" + summerCount;
                    summerCount++;
                }
                else //name tables as "tblYrXSemX"
                {
                    tables[index].Name = "tblYr" + yearCount + "Sem" + semCount;
                }
                if (semCount == numOfSemsPerYr) //if sem count is equal to numOfSemsPerYr
                {
                    yearCount++; //increment year
                    semCount = 1;
                    pageYearsAndSem[index].Controls.Add(tables[index]);
                    continue;
                }
                semCount++;
                pageYearsAndSem[index].Controls.Add(tables[index]);
            }
        }
        //end of initialize dynamic components chain call

        //creates select query, calls populateDataGrid method, and fetches the data
        //start - fetch data chain call
        private void fetchData()
        {
            int summerCount = numOfTotalPages - numOfPageSemsPerYr;
            totalNumOfUnits = 0;
            String query = "Select * from ";
            SQLiteCommand selectQuery;
            int yearCount = 1, semCount = 1;
            String tblName;
            for (int counter = 1; counter <= numOfPageSemsPerYr; counter++)
            {
                tblName = "tblYr" + yearCount + "Sem" + semCount;
                if (semCount == numOfSemsPerYr)
                {
                    yearCount++;
                    semCount = 1;
                    selectQuery = new SQLiteCommand(query + tblName, dbConnection);
                    populateDataGrid(tblName, selectQuery);
                    continue;
                }
                semCount++;
                selectQuery = new SQLiteCommand(query + tblName, dbConnection);
                populateDataGrid(tblName, selectQuery);
            }
            for (int counter = 1; counter <= summerCount; counter++)
            {
                tblName = "tblSummerTerm" + counter;
                selectQuery = new SQLiteCommand(query + tblName, dbConnection);
                populateDataGrid(tblName, selectQuery);
            }
        }
        //populates the data grid while getting necessary components for the GWA
        //TODO: re-modulize GWA components to a seperate function of themselves.
        private void populateDataGrid(String tblName, SQLiteCommand selectQuery)
        {
            double subjectWeight;
            SQLiteDataReader results = selectQuery.ExecuteReader();
            for (int index = 0; index < numOfTotalPages; index++)
            {
                if (tables[index].Name.Equals(tblName))
                {
                    while (results.Read())
                    {
                        tables[index].Rows.Add(results[columnNames[0]], results[columnNames[1]], results[columnNames[2]]);
                        subjectWeight = double.Parse(results[columnNames[1]].ToString()) * int.Parse(results[columnNames[2]].ToString());
                        totalNumOfUnits += int.Parse(results[columnNames[2]].ToString());
                        docTotalUnitsTaken = totalNumOfUnits;
                        subjectWeights.Add(subjectWeight);
                    }
                    break;
                }
            }
        }
        //end of chain call

        //computes for the totalGWA
        private void totalGWA()
        {
            double sumOfWeights = 0;
            foreach (double subject in subjectWeights)
            {
                sumOfWeights += subject;
            }
            double totalGWA = Math.Round(sumOfWeights / totalNumOfUnits, 4);
            lblTotGwa.Text = "Overall GWA: " + totalGWA.ToString();
            subjectWeights.Clear();
        }
        //computes for the GWA of the currently active tab
        private void GWA()
        {
            double totalUnits = 0;
            for (int rowCount = 0; rowCount < tables[activeTab()].RowCount; rowCount++)
            {
                double grade = double.Parse(tables[activeTab()].Rows[rowCount].Cells[1].Value.ToString()); //grades
                double units = double.Parse(tables[activeTab()].Rows[rowCount].Cells[2].Value.ToString()); //units
                totalUnits += units;
                subjectWeights.Add(grade * units);
            }
            double sumOfWeights = 0;
            foreach (double subject in subjectWeights)
            {
                sumOfWeights += subject;
            }
            double GWA = Math.Round(sumOfWeights / totalUnits, 4);
            lblGwa.Text = "GWA: " + GWA;
            subjectWeights.Clear();
        }
        //gets the currently selected tab index
        private int activeTab()
        {
            return yearPane.SelectedIndex;
        }
        //re-set the current gwa if user changes tab
        private void changeTabs(object sender, EventArgs e)
        {
            GWA();
        }
        //main method responsible for adding values on the db
        private void addValues()
        {
            String subjectName = txtBoxSubject.Text;
            String noOfUnits = comboUnits.SelectedItem.ToString();
            String grade = comboGrade.SelectedItem.ToString();

            String firstPart = "insert into ";
            String values = " VALUES('" + subjectName + "', '" + grade + "', '" + noOfUnits + "')";
            String tblName = tables[activeTab()].Name;
            SQLiteCommand insertQuery = new SQLiteCommand(firstPart + tblName + values, dbConnection);
            insertQuery.ExecuteNonQuery();
            writeToUserLogs("Added subject " + subjectName + " " + " with a grade of " + grade + " having " + noOfUnits + " unit/s.");
        }
        //main method responsible for updating values on the db
        private void updateValues()
        {
            SQLiteCommand updateQuery = new SQLiteCommand(dbConnection);
            String tblName = tables[activeTab()].Name.ToString();
            updateQuery.CommandText = "update " + tblName + " SET subjectName='" + txtBoxSubject.Text + "', grade='" + comboGrade.SelectedItem + "', noOfUnits='" + comboUnits.SelectedItem + "' WHERE subjectName='" + tables[activeTab()].CurrentRow.Cells[0].Value.ToString() + "' AND noOfUnits='" + tables[activeTab()].CurrentRow.Cells[2].Value.ToString() + "'";
            writeToUserLogs("Updated subject " + currentValues[0] + " to " + txtBoxSubject.Text + ", " + currentValues[1] + " to " + comboGrade.SelectedItem + " unit/s and a grade of " + currentValues[2] + " to " + comboUnits.SelectedItem);
            updateQuery.ExecuteNonQuery();
        }
        //gets the current values of the selected row
        private String[] fetchRowValues()
        {
            String[] values = new String[columnNames.Length];
            values[0] = tables[activeTab()].CurrentRow.Cells[0].Value.ToString();
            values[1] = tables[activeTab()].CurrentRow.Cells[1].Value.ToString();
            values[2] = tables[activeTab()].CurrentRow.Cells[2].Value.ToString();
            return values;
        }
        //main method responsible for deleting rows on the db
        private void deleteRow()
        {
            String name = tables[activeTab()].CurrentRow.Cells[0].Value.ToString();
            String grade = tables[activeTab()].CurrentRow.Cells[1].Value.ToString();
            String units = tables[activeTab()].CurrentRow.Cells[2].Value.ToString();
            String query = "delete from " + tables[activeTab()].Name.ToString() + " WHERE subjectName='" + tables[activeTab()].CurrentRow.Cells[0].Value.ToString() + "' AND noOfUnits='" + tables[activeTab()].CurrentRow.Cells[2].Value.ToString() + "' AND grade='" + tables[activeTab()].CurrentRow.Cells[1].Value.ToString() + "'";
            DialogResult decision = MessageBox.Show("Are you sure you want to delete " + name + " with a grade of " + grade + " having " + units + " unit/s?", "Confirmation", MessageBoxButtons.OKCancel);
            if (decision == DialogResult.OK)
            {
                SQLiteCommand deleteQuery = new SQLiteCommand(query, dbConnection);
                deleteQuery.ExecuteNonQuery();
                writeToUserLogs("Deleted subject " + name + " " + " with a grade of " + grade + " having " + units + " unit/s.");
                clearTables();
                fetchData();
                totalGWA();
                GWA();
            }
        }
        //clear the tables before performing adding/update/deleting of data
        private void clearTables()
        {
            for (int index = 0; index < numOfTotalPages; index++)
            {
                tables[index].Rows.Clear();
            }
        }
        //method that disables some functionalities depending on the editting mode
        private void modes(int mode)
        {
            switch (mode)
            { //normal view mode
                case 1:
                    functionsBox.Enabled = true;
                    controlBox.Enabled = false;
                    txtBoxSubject.Text = "Subject Name: ";
                    txtBoxSubject.ForeColor = System.Drawing.SystemColors.WindowFrame;
                    break;
                case 2: //add mode
                    functionsBox.Enabled = false;
                    controlBox.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                case 3: //update mode
                    functionsBox.Enabled = false;
                    controlBox.Enabled = true;
                    break;
            }
            currentMode = mode;
        }
        //creates a report file in .docx format
        //start of chain call
        private void generateReport()
        {
            String headerFontStyle = "Century Gothic";
            int subSubHeadingSize = 20;

            exportedDoc = DocX.Create(docName); //creates doc file
            exportedDoc.AddFooters();
            Footer docFooters = exportedDoc.Footers.odd;
            DateTime currentTime = DateTime.Now;
            docFooters.InsertParagraph("Generated at: " + currentTime.ToString()).Alignment = Alignment.right;

            setParagraph(true, docUniversity, Alignment.center, subSubHeadingSize, headerFontStyle);
            setParagraph(true, docSchoolAddr, Alignment.center, subSubHeadingSize - 11, headerFontStyle);
            setParagraph(true, "Name: \t\t\t" + docUserName, "Course: \t\t\t" + lblCourse.Text, "Year: \t\t\t" + docYearLevel, lblTotGwa.Text.Replace("Overall GWA: ", "Overall GWA: \t\t"), "Units taken: \t\t" + docTotalUnitsTaken);
            setParagraph(true, "Summary of Grades", Alignment.center, subSubHeadingSize - 2, headerFontStyle);
            int docTableRowIndex = 1; //doc table row starts at [1][x] since [0][x] are column header/s.
            Table grades;
            for (int index = 0; index < numOfTotalPages; index++) //index = data grid index
            {
                setParagraph(true, tables[index].Name.Replace("tbl", "").Replace("Yr", "Year ").Replace("Sem", ", Sem ") + "\n", Alignment.center, subSubHeadingSize - 4, headerFontStyle);
                grades = exportedDoc.AddTable(tables[index].RowCount + 1, tables[index].ColumnCount);
                grades.Alignment = Alignment.center;
                grades.Design = TableDesign.ColorfulListAccent6;
                for (int columnCount = 0; columnCount < tables[index].ColumnCount; columnCount++) //column headers
                {
                    grades.Rows[0].Cells[columnCount].InsertParagraph(setParagraph(false, tables[index].Columns[columnCount].HeaderText));
                }

                for (int rowCount = 0; rowCount < tables[index].RowCount; rowCount++)
                {
                    for (int cellIndex = 0; cellIndex < tables[index].ColumnCount; cellIndex++)
                    {
                        grades.Rows[docTableRowIndex].Cells[cellIndex].InsertParagraph(setParagraph(false, tables[index].Rows[rowCount].Cells[cellIndex].Value.ToString()));
                    }
                    docTableRowIndex += 1;
                }
                docTableRowIndex = 1;
                exportedDoc.InsertTable(grades);
                if (index != numOfTotalPages - 1)
                {
                    exportedDoc.InsertSectionPageBreak(true);
                }
            } //ayus sa settings, reload and create new db pag ka pinaltan
            //konting ayus sa methods and deploy
            //ok na after
            exportedDoc.InsertParagraph("\n\n---------END OF REPORT---------").Font(new FontFamily(headerFontStyle)).FontSize(subSubHeadingSize - 4).Alignment = Alignment.center;
            exportedDoc.Save();
            Process.Start(docName);
        }
        //appends new default styled paragraph to the exported .docx file
        private Paragraph setParagraph(bool isAdded, params String[] paragraphs)
        {
            String defaultFont = "Century Gothic";
            int defaultFontSize = 14;
            Paragraph text = exportedDoc.InsertParagraph();
            foreach (String sentence in paragraphs)
            {
                text.AppendLine(sentence).FontSize(defaultFontSize).Font(new FontFamily(defaultFont));
            }
            text.AppendLine();
            if (!isAdded)
            {
                exportedDoc.RemoveParagraph(text);
                text.Alignment = Alignment.center;
            }
            return text;
        }
        //appends new custom styled paragraph to the exported .docx file
        private Paragraph setParagraph(bool isAdded, String paragraph, Alignment position, int fontSize, String fontStyle)
        {
            Paragraph text = exportedDoc.InsertParagraph();
            text.Append(paragraph).FontSize(fontSize).Font(new FontFamily(fontStyle)).
                Alignment = position;
            if (!isAdded)
            {
                exportedDoc.RemoveParagraph(text);
            }
            return text;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            try
            {
                halt();
            }
            catch (Exception exception)
            {
                MessageBox.Show("System error encountered. Please try again.\n" + exception.StackTrace);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            Process.Start("about.txt");
        }

        private void txtBoxSubject_Click(object sender, EventArgs e)
        {
            txtBoxSubject.Text = "";
            txtBoxSubject.ForeColor = System.Drawing.SystemColors.InfoText;
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            String message = "Re-start the application after saving the config file.";
            Process.Start(configPath);
            MessageBox.Show(message, "NOTE",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            modes(2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            modes(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMode == 2) //add mode
            {
                addValues();
            }
            else //update mode
            {
                updateValues();
            }
            clearTables();
            fetchData();
            totalGWA();
            GWA();
            modes(1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(activeRow().ToString());
            //MessageBox.Show(tables[0].CurrentRow.Cells[2].Value.ToString());
            //tanggalin active row na method
            String[] rowValues = fetchRowValues();
            txtBoxSubject.ForeColor = System.Drawing.SystemColors.InfoText;
            txtBoxSubject.Text = rowValues[0];
            comboUnits.SelectedItem = int.Parse(rowValues[2]);
            comboGrade.SelectedItem = double.Parse(rowValues[1]);
            currentValues = new string[3];
            currentValues[0] = txtBoxSubject.Text;
            currentValues[1] = comboGrade.SelectedItem.ToString();
            currentValues[2] = comboUnits.SelectedItem.ToString();
            modes(3);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            generateReport();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private ArrayList subjectWeights;
        private SQLiteConnection dbConnection;
        private DocX exportedDoc;
        private DataGridView[] tables;
        private StreamReader currentConfig;
        private int numOfPageSemsPerYr;
        private int numOfTotalPages;
        private int numOfSemsPerYr;
        private int totalNumOfUnits;
        private int docTotalUnitsTaken;
        private int currentMode;
        private String docUserName;
        private String docYearLevel;
        private String docUniversity;
        private String docSchoolAddr;
        private String warning = "hello";
        private String[] currentValues;
        private String[] columnNames = { "subjectName", "grade", "noOfUnits" };
        private String userLogsPath = "userLogs.txt", configPath = "config.ini",
                       databaseName = "mainDB.db",
                       aboutPath = "about.txt", docName;
    }
}
