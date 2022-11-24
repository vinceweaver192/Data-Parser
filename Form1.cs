using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class Form1 : Form
    {
        static Microsoft.FSharp.Collections.FSharpList<HW5P2Lib.HW5P2.Article> alldata;
        static MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String fileNameFromText = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(fileNameFromText);


            String userInput = textBox3.Text;

            // Take the user's input, get an integer to pass to F# code
            string result = userInput;

            // Call the library function
            int libFunc = Int32.Parse(result);

            // Output the result
            textBox1.Text = (Environment.NewLine + String.Format("Title: {0}", HW5P2Lib.HW5P2.getTitle(libFunc, alldata)));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String filename = textBox2.Text;

            alldata = HW5P2Lib.HW5P2.readfile(filename);

            // Take the user's input, get an integer to pass to F# code
            String userInput = textBox3.Text;

            // Call the library function
            int libFunc = Int32.Parse(userInput);

            // Take the user's input, get an integer to pass to F# code
            // Call the library function
            // Output the result
            textBox1.Text = Environment.NewLine + String.Format("Number of Words in The Article: {0}", HW5P2Lib.HW5P2.wordCount(libFunc, alldata));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;

            alldata = HW5P2Lib.HW5P2.readfile(filename);


            // Take the user's input, get an integer to pass to F# code
            string userInput = textBox3.Text;

            // Call the library function
            int libFunc = Int32.Parse(userInput);

            // Output the result
            textBox1.Text = Environment.NewLine + String.Format("Month of Chosen Article: {0}", HW5P2Lib.HW5P2.getMonthName(libFunc, alldata));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);

            textBox1.Text = ("Unique Publishers: ");

            Microsoft.FSharp.Collections.FSharpList<string> publisherList;
            publisherList = HW5P2Lib.HW5P2.publishers(alldata);

            textBox1.Text = textBox1.Text + (String.Join(Environment.NewLine, publisherList));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            String filename = textBox2.Text; 

            alldata = HW5P2Lib.HW5P2.readfile(filename);

            textBox1.Text = ("Unique Countries: \n ");

            Microsoft.FSharp.Collections.FSharpList<string> countryList;
            countryList = HW5P2Lib.HW5P2.countries(alldata);

            textBox1.Text = textBox1.Text + ("\n" + (String.Join(Environment.NewLine, countryList)));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);

            textBox1.Text = ("Average News Guard Score for All Articles:");

            textBox1.Text = textBox1.Text + Environment.NewLine + HW5P2Lib.HW5P2.avgNewsguardscoreForArticles(alldata);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);

            Microsoft.FSharp.Collections.FSharpList<Tuple<string, int>> articleList;
            articleList = HW5P2Lib.HW5P2.numberOfArticlesEachMonth(alldata);

            textBox1.Text = ("Number of Articles for Each Month:");

            string histogram = HW5P2Lib.HW5P2.buildHistogram(articleList, alldata.Length, "");

            string result = histogram.Replace("/n", Environment.NewLine);

            textBox1.Text = textBox1.Text + Environment.NewLine + result;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);

            Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> articleList;
            articleList = HW5P2Lib.HW5P2.reliableArticlePercentEachPublisher(alldata);

            textBox1.Text = ("Percentage of Articles That Are Reliable for Each Publisher: \n");

            Microsoft.FSharp.Collections.FSharpList<string> percentList; 
            percentList = HW5P2Lib.HW5P2.printNamesAndPercentages(articleList);

            foreach (string data in percentList)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + data;
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            string filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);

            // Call the library function to get the list of (string, double) for each country's average
            textBox1.Text = ("Average News Guard Score for Each Country: \n");

            //countryNames = HW5P2Lib.HW5P2.countries(alldata);
            //var averageguard = HW5P2Lib.HW5P2.avgNewsguardscoreEachCountry(alldata, countryNames);

            //string countryNames;
            //var score = HW5P2Lib.HW5P2.avgNewsguardscoreEachCountry(alldata, countryNames);

            Microsoft.FSharp.Collections.FSharpList<string> countryList;
            
            countryList = HW5P2Lib.HW5P2.printNamesAndFloats(HW5P2Lib.HW5P2.averageguardscore(alldata));

            foreach (string country in countryList)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + country;
            }
            // Call the library function transforming the list of pairs into a list of strings
            // Output the list of strings, one per line


            //var countryNames = HW5P2Lib.HW5P2.countries(alldata);
            //var averageguard = HW5P2Lib.HW5P2.avgNewsguardscoreEachCountry(alldata, countryNames);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            String filename = textBox2.Text;
            alldata = HW5P2Lib.HW5P2.readfile(filename);


            textBox1.Text = ("The Average News Guard Score for Each Political Bias Category: ");

            String histogram = HW5P2Lib.HW5P2.buildHistogramFloat(HW5P2Lib.HW5P2.avgNewsguardscoreEachBias(alldata), "");

            string result = histogram.Replace("/n", Environment.NewLine);

            textBox1.Text = textBox1.Text + Environment.NewLine + result;

        }
        
        private void button11_Click(object sender, EventArgs e)
        {

            
            string connStr = "server=" + textBox4.Text + ";" +
                      "user=" + textBox6.Text + ";" +
                      "database=" + textBox8.Text + ";" +
                      "port=" + textBox5.Text + ";" +
                      "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);                  
            conn.Open();



            String userInput = textBox3.Text;
            int nid = Int32.Parse(userInput);
            try
            {
                // retrieve and print result
                string query = String.Format(@"
                SELECT title
                FROM news
                WHERE news_id = {0};", nid);

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}", reader.GetName(0)));

                while (reader.Read())
                {

                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}", reader.GetString(0)));

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;  
            conn = new MySqlConnection(connStr);                                                    
            conn.Open();

            try
            {
                // retrieve and print result
                string query = String.Format(@"
                SELECT news_id, LENGTH(body_text) AS length
                FROM news
                WHERE LENGTH(body_text)>100
                ORDER BY news_id;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1)));

                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}", reader.GetInt32(0), reader.GetInt32(1)));
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {
                // retrieve and print result
                string query = String.Format(@"
                            SELECT title, DATE_FORMAT(STR_TO_DATE(publish_date, '%c/%d/%y'), '%M') AS Month
                            FROM news
                            ORDER BY STR_TO_DATE(publish_date, '%m/%d/%y')");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1)));

                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}", reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private void button16_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {

                string query = String.Format(@"
                            SELECT publisher
                            FROM publisher_table
                            JOIN news
                            USING (publisher_id)
                            GROUP BY publisher
                            ORDER BY publisher;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}", reader.GetName(0)));

                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}", reader.GetString(0)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {

                string query = String.Format(@"
                SELECT country, COUNT(news_id) articleCount
                FROM news
                RIGHT JOIN country_table
                USING (country_id)
                GROUP BY country
                ORDER BY articleCount DESC;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1)));
                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}", reader.GetString(0), reader.GetInt32(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



        private void button14_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {

                string query = String.Format(@"
                SELECT AVG(news_guard_score) AS `Average Score`
                FROM news;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}", reader.GetName(0)));
                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}", reader.GetInt32(0)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        private void button17_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;  // change the database and password to test on your machine
            conn = new MySqlConnection(connStr);                                                     // must be these values when submitting to gradescope
            conn.Open();

            try
            {
                // retrieve and print result
                string query = String.Format(@"
                            SELECT month, COUNT(*) AS numArticles, AVG(overallCount) AS overall, ROUND((100*COUNT(*)/AVG(overallCount)),2)  AS percentage -- , STR_TO_DATE(publish_date, '%m/%d/%y'), 
                            FROM 
                            (
                                SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month
                                FROM news
                            ) AS monthTable
                            JOIN (SELECT COUNT(*) overallCount FROM news) AS overallCountTable
                            GROUP BY month
                            ORDER BY month;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3)));
                while (reader.Read())
                {
                    textBox1.Text += Environment.NewLine + (String.Format("{0}\t{1}\t{2}\t{3}", reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private void button18_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {

                string query = String.Format(@"
                            SELECT publisher, ROUND(AVG(reliability)*100, 2) AS percentage
                            FROM news
                            JOIN publisher_table
                            USING (publisher_id)
                            GROUP BY publisher;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1)));
                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}", reader.GetString(0), reader.GetDecimal(1)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;  
            conn = new MySqlConnection(connStr);                                                    
            conn.Open();

            try
            {
                // retrieve and print result
                string query = String.Format(@"
                            SELECT month, COUNT(*) AS numArticles, 
                            AVG(overallCount) AS overall, 
                            ROUND((100*COUNT(*)/AVG(overallCount)),2)  AS percentage -- , 
                            STR_TO_DATE(publish_date, '%m/%d/%y'), 
                            FROM 
                            (
                                SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month
                                FROM news
                            ) AS monthTable
                            JOIN (SELECT COUNT(*) overallCount FROM news) AS overallCountTable
                            GROUP BY month
                            ORDER BY month;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3)));
                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}\t{2}\t{3}", reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + textBox4.Text + ";" +
                            "user=" + textBox6.Text + ";" +
                            "database=" + textBox8.Text + ";" +
                            "port=" + textBox5.Text + ";" +
                            "password=" + textBox7.Text;
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {
                

                string query = String.Format(@"
                            SELECT author, political_bias, COUNT(*) AS numArticles
                            FROM news
                            JOIN news_authors
                            USING (news_id)
                            JOIN author_table
                            USING (author_id)
                            JOIN political_bias_table
                            USING (political_bias_id)
                            GROUP BY author, political_bias
                            ORDER BY author, numArticles DESC, political_bias;");

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                textBox1.Text = (String.Format("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2)));
                while (reader.Read())
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + (String.Format("{0}\t{1}\t{2}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        
        
    }
}
