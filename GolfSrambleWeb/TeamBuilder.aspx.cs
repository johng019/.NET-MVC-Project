using GolfSrambleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GolfSrambleWeb
{
    public partial class TeamBuilder : System.Web.UI.Page
    {
        public Button AcceptButton { get; private set; }
        public object DragDropEffects { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            AcceptButton = Button1;
            TextBox1.Focus();
        }

    protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                try
                {
                    string fullName = TextBox1.Text;
                    var split = fullName.Split();
                    string firstName = split[0].ToString();
                    string lastName = split[1].ToString();
                    string phone = " ";
                    string email = " ";
                    string date = DateTime.Now.ToShortDateString();
                    string score = " ";
                    string winnings = " ";

                    if (CheckBox1.Checked)
                    {      
                        ListBox1.Items.Add(TextBox1.Text);
                        CheckBox1.Checked = false;
                        TextBox1.Text = "";
                    }
                    if (CheckBox2.Checked)
                    {
                        ListBox2.Items.Add(TextBox1.Text);
                        CheckBox2.Checked = false;
                        TextBox1.Text = "";
                    }
                    if (CheckBox3.Checked)
                    {
                        ListBox3.Items.Add(TextBox1.Text);
                        CheckBox3.Checked = false;
                        TextBox1.Text = "";
                    }
                    TextBox1.Focus();

                }
                catch
                {
                    return;
                }
                finally
                {
                    TextBox1.Text = "";
                }
            }
            
        }
        [WebMethod,ScriptMethod]
        public void Button2_Click(object sender, EventArgs e)
        {
            
            ListView1.Visible = false;
          
            int x = 1;

            Random rand = new Random();
            
            int r = rand.Next(ListBox2.Items.Count);
            int s = rand.Next(ListBox3.Items.Count);

            for (int i = 0; i <= ListBox1.Items.Count -1; i++)
            {
                if(ListBox2.Items.Count <1)
                {
                    return;
                }
                if (ListBox3.Items.Count < 1)
                {
                    return;
                }
                ListBox4.Items.Add("Team" + x + " is: A: " + ListBox1.Items[i].ToString() + " , B: " + ListBox2.Items[r].ToString() + " , C: " + ListBox3.Items[s].ToString());
                x++;
                ListBox1.Items.RemoveAt(i);
                ListBox2.Items.RemoveAt(r);
                ListBox3.Items.RemoveAt(s);
                r = rand.Next(ListBox2.Items.Count);
                s = rand.Next(ListBox3.Items.Count);
            }
        }
        public void ListView1_OnClick(object sender, EventArgs e)
        {
            /*
            foreach(char item in level)
            {
                if (level == "A"){
                    ListBox1.Items.Add(level);
                }
                if (level == "B")
                {
                    ListBox2.Items.Add(level);
                }
                if (level == "C")
                {
                    ListBox3.Items.Add(level);
                }
            }*/
        }
            
    }
}