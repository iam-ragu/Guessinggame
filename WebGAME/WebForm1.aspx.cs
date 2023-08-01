using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebGAME
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connectionString = "Data Source=RAGUNATH947\MSSQLSERVER01;Initial Catalog = EmpyDB; Integrated Security = True";

        private int generatedNumber;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                generatedNumber = GeneratedRandomNumber();
                Session["GeneratedNumber"] = generatedNumber;
            }
                
        }

        private int GeneratedRandomNumber()
        {
            throw new NotImplementedException();
        }

        protected void SubmitButton_Click (object sender, EventArgs e)
        {
            int playerGuess;
            if (int.TryParse(txtGuess.Text, out playerGuess))
            {
                int generatedNumber = (int)Session["GeneratedNumber"];
                string playerName = "Player";

                string query = "INSERT INTO Guesses (PlayerName, GuessValue, GeneratedNumber, DateTime) VALUES (@PlayerName, @GuessValue, @GeneratedNumber, @DateTime)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlayerName", playerName);
                        command.Parameters.AddWithValue("@GuessValue", playerGuess);
                        command.Parameters.AddWithValue("@GeneratedNumber", generatedNumber);
                        command.Parameters.AddWithValue("@DateTime", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }

                if (playerGuess == generatedNumber)
                {
                    lblFeedback.Text = "Congratulations! You guessed it right!";
                    txtGuess.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else if (playerGuess < generatedNumber)
                {
                    lblFeedback.Text = "Too low! Try again.";
                }
                else
                {
                    lblFeedback.Text = "Too high! Try again.";
                }
            }
            else
            {
                lblFeedback.Text = "Please enter a valid number.";
            }
        }

        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 101); 






        }
    }
}