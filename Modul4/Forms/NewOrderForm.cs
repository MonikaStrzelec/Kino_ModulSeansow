using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul4
{
    public partial class NewOrderForm : Form
    {
        projektkinoEntities1 _context;
        public NewOrderForm()
        {
            InitializeComponent();
        }

        new private void Refresh()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            foreach (Pack pack in projektkinoEntities1.Pack.ToList())
            {
                listBox1.Items.Add(pack);
            }

            listBox1.SelectedIndex = 0;
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            List<Pack> packlist = new List<Pack>();
            bool temp = true;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select item to add!");
            }
            else
            {
                using (var context = new projektkinoEntities1())
                {
                    _context = context;
                    foreach (Pack pack in listBox2.Items)
                    {
                        packlist.Add(pack);
                    }
                    listBox2.Items.Clear();
                    packlist.Add((Pack)listBox1.SelectedItem);
                    foreach (Pack pack in packlist)
                    {
                        List<PackPO> packPOs = context.PackPO.Where(x => x.PackID == pack.IDPack).ToList();
                        foreach (PackPO packpo in packPOs)
                        {
                            Product product = (Product)context.Product.FirstOrDefault(x => x.IDProduct == packpo.ProductID);
                            product.Amount = product.Amount - packpo.Amount;
                            context.Set<Product>().AddOrUpdate(product);
                            if (product.Amount >= 0)
                            {
                                temp = true;
                            }
                            else { MessageBox.Show("Lack of products");
                                temp = false;
                                break;
                            }

                        }
                        if (temp)
                        {
                            listBox2.Items.Add(pack);
                        }
                    }
                    packlist.Clear();

                }
            }
            UpdateValueLabel();
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Select item to delete!");
            }
            else
                listBox2.Items.Remove(listBox2.SelectedItem);
                UpdateValueLabel();
        }

        private void cancelOrderBtn_Click(object sender, EventArgs e)
        {
            valueLabel.Text = "0.00";
            listBox2.Items.Clear();
            MessageBox.Show("Order cleared");
        }

        private void confirmOrderBtn_Click(object sender, EventArgs e)
        {
            if(!(listBox2.Items.Count > 0))
            {
                MessageBox.Show("You have to add something to order");
                return;
            }
            Sale sale = new Sale();
            int userId = 1; // Do zmiany uprawnień
            int id = sale.add(userId, DateTime.Now, GetPrice());
            foreach (Pack pack in listBox2.Items)
            {
                SalePO salePO = new SalePO();
                salePO.add(id, pack);
            }

            using (var context = new projektkinoEntities1())
            {
                foreach (Pack pack in listBox2.Items)
                {
                    List<PackPO> packPOs = context.PackPO.Where(x => x.PackID == pack.IDPack).ToList();
                    foreach (PackPO packpo in packPOs)
                    {
                        Product product = (Product)context.Product.FirstOrDefault(x => x.IDProduct == packpo.ProductID);
                        product.Amount = product.Amount - packpo.Amount;
                        context.Set<Product>().AddOrUpdate(product);
                    }
                }
                context.SaveChanges();
            }

            MessageBox.Show("Added pack");
            Refresh();
        }

        private void UpdateValueLabel()
        {
            valueLabel.Text = GetPrice().ToString();
        }

        private decimal GetPrice()
        {
            decimal value = 0.00M;
            foreach (Pack pack in listBox2.Items)
            {
                value += pack.Price;
            }
            return value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGridView();
        }

        private void SetGridView()
        {
            Pack temp = (Pack)listBox1.SelectedItem;

            using (var context = new projektkinoEntities1())
            {
                var query = from st in context.PackPO
                            where st.PackID == temp.IDPack
                            from sy in context.Product
                            where st.ProductID == sy.IDProduct
                            select sy;
                infoGrid.DataSource = query.ToList<Product>();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
