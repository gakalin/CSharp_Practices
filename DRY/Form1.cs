using DRYDemoLibrary;

namespace DRY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            EmployeeProcessor processor = new EmployeeProcessor();
            employeeID.Text = processor.GenerateEmployeeID(firstName.Text, lastName.Text);
        }
    }
}