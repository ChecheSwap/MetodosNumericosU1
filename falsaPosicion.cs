using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos
{
    public partial class falsaPosicion : biseccioni
    {
        public double deltx = 0;
        
        public falsaPosicion()
        {
            InitializeComponent();
            this.Text = label1.Text;
        }

        private void falsaPosicion_Load(object sender, EventArgs e)
        {
            
        }

        private void createTable()
        {
            this.tabla = new DataTable();
            tabla.Columns.Add("A", typeof(double));
            tabla.Columns.Add("B", typeof(double));
            tabla.Columns.Add("f(A)", typeof(double));
            tabla.Columns.Add("f(B)", typeof(double));
            tabla.Columns.Add("\u25B2 X", typeof(double));
            tabla.Columns.Add("Xn", typeof(double));
            tabla.Columns.Add("f(Xn)", typeof(double));
        }

        private bool setRow()
        {
            bool rule = false;

            if (a < b)
                rule = false;
            else if (a > b)
                rule = true;          

            this.fa = FUNCTIONS.getImage(a);
            this.fb = FUNCTIONS.getImage(b);

            MessageBox.Show(fa.ToString());
            MessageBox.Show(fb.ToString());

            if (!((fa > 0 && fb < 0) || (fb > 0 && fa < 0)))
            {
               
                MessageBox.Show("No existe un cambio de signo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            while (true)
            {
                this.fa = FUNCTIONS.getImage(a);
                this.fb = FUNCTIONS.getImage(b);
                this.deltx = (fa)*(b - a) / (Math.Abs(fa) + Math.Abs(fb));

                if (rule)
                    convertNegative(ref deltx);
                else
                    convertPositive(ref deltx);

                xn = a + deltx;
                fxn = FUNCTIONS.getImage(xn);

                this.tabla.Rows.Add(a, b, fa, fb, deltx, xn, fxn);
                
                if (Math.Abs(deltx) <= tolerancy)
                    return true;
                a = xn;
            }
                        
        }
        
        private void convertNegative(ref double val)
        {
            if (val > 0)
                val *= -1;
        }

        private void convertPositive(ref double val)
        {
            if (val < 0)
                val *= -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.getValues();
            this.createTable();
            if (this.setRow())
            {
                this.dataGridView1.DataSource = this.tabla;
                this.dataGridView1.Rows[this.dataGridView1.RowCount--].Cells[5].Style.BackColor = Color.BlueViolet;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.getValues();
            this.createTable();
            if (this.setRow())
            {
                this.dataGridView1.DataSource = this.tabla;
                int index = this.dataGridView1.RowCount;
                this.dataGridView1.Rows[index-1].Cells[5].Style.BackColor = Color.CadetBlue;
                foreach(DataGridViewRow x in this.dataGridView1.Rows)
                {
                    x.HeaderCell.Value = (x.Index+1).ToString();
                }
            }
        }
    }
}
