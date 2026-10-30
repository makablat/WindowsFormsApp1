using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using WindowsFormsApp1.ModelEF;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       Model1 model = new Model1();

        private void StartLoadData()
        { 
            model.Users.Load();
        role_NameComboBox.DataSource = model.Roles.ToList();
        usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }

        private void SaveData()
        { 
         try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                model.SaveChanges();
            }
        }
 private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
         private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
    
       
    }

