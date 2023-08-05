namespace _08._07._23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ListView lv = new ListView();

            lv.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            lv.View = View.Details;
            lv.LabelEdit = true;
            lv.AllowColumnReorder = true;
            lv.CheckBoxes = true;
            lv.FullRowSelect = true;
            // lv.GridLines = true;

            var small = new ImageList();
            var large = new ImageList();

            small.Images.Add("0", Image.FromFile("../../../Resources/Victory_small.jpg"));
            small.Images.Add("1", Image.FromFile("../../../Resources/SSD_small.jpg"));
            small.Images.Add("2", Image.FromFile("../../../Resources/Tour_small.jpg"));
            small.Images.Add("3", Image.FromFile("../../../Resources/VYD_small.jpg"));
            small.Images.Add("4", Image.FromFile("../../../Resources/Rose_small.jpg"));

            large.Images.Add("3", Image.FromFile("../../../Resources/Victory_large.jpg"));
            large.Images.Add("0", Image.FromFile("../../../Resources/SSD_large.jpg"));
            large.Images.Add("4", Image.FromFile("../../../Resources/Tour_large.jpg"));
            large.Images.Add("1", Image.FromFile("../../../Resources/VYD_large.jpg"));
            large.Images.Add("2", Image.FromFile("../../../Resources/Rose_large.jpg"));
          
            string path = @"../../../Resources/wiches.txt";

            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не знайдений!");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(path);
                int index = 0;
                for (int i = 0; i < lines.Length; i += 2)
                {
                    var it = new ListViewItem(lines[i], index + "");
                    it.SubItems.Add(lines[i + 1]);
                    index++;
                    lv.Items.Add(it);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }

            lv.Columns.Add("подарунок", 190, HorizontalAlignment.Left);
            lv.Columns.Add("вартiсть", 100, HorizontalAlignment.Center);

            lv.LargeImageList = large;
            lv.SmallImageList = small;

            this.Controls.Add(lv);
        }
    }
}