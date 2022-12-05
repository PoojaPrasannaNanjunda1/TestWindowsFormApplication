/***********************************
** WinFormsTestApp1.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace WinFormsTestApp1
{
    using System.Data.SQLite;
    using System.Windows.Forms;
    using global::WinFormsTestApp1.Entities;

    /// <summary>
    /// Partial class for WinFormsTestApp1.
    /// </summary>
    public partial class WinFormsTestApp1 : Form
    {
        /// <summary>
        /// The sql connection object.
        /// </summary>
        private SQLiteConnection? sqliteConn;

        /// <summary>
        /// The application settings object.
        /// </summary>
        private ApplicationSettings? settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinFormsTestApp1"/> class.
        /// </summary>
        public WinFormsTestApp1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This event handler will be invoked when the windows form is loaded.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.settings = new ApplicationSettings()
            {
                DatabasePath = System.Configuration.ConfigurationManager.AppSettings["DatabasePath"],
                ApplicationInstanceName = System.Configuration.ConfigurationManager.AppSettings["ApplicationInstanceName"],
            };

            if (this.settings == null)
            {
                MessageBox.Show("Error occurred while reading the appsettings.json file. Please check the appsettings.json file.");
                Application.Exit();
            }

            this.Text = this.settings.ApplicationInstanceName;

            this.sqliteConn = this.CreateConnection();
            if (this.sqliteConn == null)
            {
                MessageBox.Show("The application could not create database connection.");
                Application.Exit();
            }

            if (!this.CreateTableIfNotExists(this.sqliteConn))
            {
                MessageBox.Show("Exception occurred while creating the table.");
                return;
            }

            // Create a seperate thread to process the data from WebApplication.
            var readTableThread = new Thread(this.ReadDataFromWebApp);
            readTableThread.IsBackground = true;

            // Start the thread to read the data entered by the web application.
            readTableThread.Start();
        }

        /// <summary>
        /// This method reads the data entered by the web application on 1 second interval.
        /// </summary>
        private void ReadDataFromWebApp()
        {
            try
            {
                // condition to make sure that the thread reads the data continuously.
                while (true)
                {
                    // counter to manage the new entry by the web application.
                    int counter = 0;
                    SQLiteDataReader sqlite_datareader;
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = this.sqliteConn.CreateCommand();

                    // Query to read entered by the 'WebApplication'.
                    sqlite_cmd.CommandText = "SELECT TextData FROM DataTable WHERE Sender == 'WebApplication'";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        string myreader = sqlite_datareader.GetString(0);
                        if (!string.IsNullOrEmpty(myreader))
                        {
                            counter++;
                            this.Invoke((MethodInvoker)(() => this.HandleListBoxData(myreader, counter)));
                        }
                    }

                    Task.Delay(1000).Wait();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while reading the data entered by the web application. Exception is: {ex} ");
                return;
            }
        }

        /// <summary>
        /// This method adds the text data into the listbox only if the new item is entered by the web application.
        /// </summary>
        /// <param name="dataItem">The data Item.</param>
        /// <param name="counter">The counter to manage the new item to be inserted to the listbox.</param>
        private void HandleListBoxData(string dataItem, int counter)
        {
            var listBoxlength = this.OutputListBox.Items.Count;
            this.OutputListBox.HorizontalScrollbar = true;

            // Add the item to the output only when the new item is entered by the web application.
            if (listBoxlength < counter)
            {
                this.OutputListBox.Items.Add(dataItem);
            }
        }

        /// <summary>
        /// This method creates the connection to the database.
        /// </summary>
        /// <returns>The connection object.</returns>
        private SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;

            // Create a new database connection:
            sqlite_conn = new SQLiteConnection($"Data Source= {settings.DatabasePath}; Version = 3; New = True; Compress = True; ");

            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exceotion occurred while connecting to the database, the exception is: {ex}");
                return null;
            }

            // return the connection object.
            return sqlite_conn;
        }

        /// <summary>
        /// This method will be invoked when Submit button is pressed by the user.
        /// This method insert the data into the data table.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Submitbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.InputTextBox.Text))
            {
                MessageBox.Show("Please enter the input text before pressing submit button.");
            }
            else
            {
                if (!this.InsertDataIntoTheTable(this.InputTextBox.Text))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// This method inserts the data into the database table.
        /// </summary>
        /// <param name="input">The input data string.</param>
        /// <returns>true if the insert operation is successful.</returns>
        private bool InsertDataIntoTheTable(string input)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = this.sqliteConn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO DataTable (TextData, Sender) VALUES('{input}', '{settings.ApplicationInstanceName}');";
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred while writing the message to the database. The exception is: {ex}");
                return false;
            }
        }

        /// <summary>
        /// This method creates the table in the database.
        /// </summary>
        /// <param name="conn">The sql connection object.</param>
        /// <returns>true if the table creation is successful.</returns>
        private bool CreateTableIfNotExists(SQLiteConnection conn)
        {
            try
            {
                // create DataTable
                SQLiteCommand sqlite_cmd;
                string createTestTable1 = "CREATE TABLE IF NOT EXISTS DataTable (TextData VARCHAR(200), Sender VARCHAR(100))";
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = createTestTable1;
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}