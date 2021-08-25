using Newtonsoft.Json;
using ProductConsult.Models;
using System;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;
using System.Text.Json;
using System.Collections.Generic;

namespace ProductConsult
{
    public partial class ProductConsult : Form
    {
        public ProductConsult()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strURL = "https://localhost:5001/api/products";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(strURL).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(result);
                    DataTable dt = new DataTable();
                    DataView view;
                    DataRow dataRow;

                    DataColumn column;
                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Descrição";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "Preço";
                    dt.Columns.Add(column);

                    foreach (var p in products)
                    {
                        dataRow = dt.NewRow();
                        dataRow["Descrição"] = p.Description;
                        dataRow["Preço"] = p.Price;

                        dt.Rows.Add(dataRow);
                    }
                    view = new DataView(dt);
                    dataGridViewProducts.DataSource = view;
                }
            }
        }
    }
}
