using System.Configuration;
namespace k190146_Q3
{
    public partial class Form1 : Form
    {
        private XmlUtils xmlUtils = new XmlUtils();
        private List<string> categories = new List<string>();
        private int initialIndex = 0;
        private string folder_path = "";
        public Form1()
        {
            InitializeComponent();
            folder_path = ConfigurationManager.AppSettings["inputDir"];
            categories = DirUtils.getCategories(folder_path);
            
            if (categories.Count == 0) {
                MessageBox.Show("No folder exist in the given directory");
                return;
            }
           
            if (folder_path == null || folder_path == "") {
                MessageBox.Show("Select a valid folder path");
                return;
            }
            if (folder_path.Last() != '\\')
            {
                folder_path = folder_path + "\\";
            }
            
            foreach (string category in categories) {
                //MessageBox.Show(category[0]+ "d");
                listBox1.Items.Add(category);

                
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                int index = listBox1.SelectedIndex;
                initialIndex = index;
                string category = categories[index];
           

            string xmlFileName = DirUtils.getLatestFile(folder_path + category);
            

            string full_path = folder_path + category + xmlFileName;
            List<Stock> stocks = xmlUtils.parseXml(full_path);

            foreach (Stock stock in stocks)
            {
                dataGridView1.Rows.Add(stock.name, stock.price);
            }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                
                string category = categories[initialIndex];
                

                string xmlFileName = DirUtils.getLatestFile(folder_path + category);

                string full_path = folder_path + category + xmlFileName;
                List<Stock> stocks = xmlUtils.parseXml(full_path);

                foreach (Stock stock in stocks)
                {
                    dataGridView1.Rows.Add(stock.name, stock.price);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

       
    }
}