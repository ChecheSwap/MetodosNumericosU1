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
    public partial class newtonRaphson : biseccioni
    {
        protected double x0, fx0, fdx0, detx;
        public newtonRaphson()
        {
            InitializeComponent();
        }

        private void newtonRaphson_Load(object sender, EventArgs e)
        {

        }

        private void setModel()
        {
            this.tabla = new DataTable();
            tabla.Columns.Add("X0", typeof(double));
            tabla.Columns.Add("f(x0)", typeof(double));
            tabla.Columns.Add("f'(x0)", typeof(double));
            tabla.Columns.Add("\u25B2 X", typeof(double));
            tabla.Columns.Add("Xn", typeof(double));
            tabla.Columns.Add("f(Xn)", typeof(double));            
        }

        private bool setRows()
        {
            int cont = 0;

            x0 = a;            
            while (true)
            {
              
               // MessageBox.Show(x0.ToString());
                fx0 = FUNCTIONS.getImage(x0);
               // MessageBox.Show(fx0.ToString());
                fdx0 = RAPHSON.getFunctionDerivate(x0);
               // MessageBox.Show(fdx0.ToString());
                this.detx = fx0 / fdx0;
                //MessageBox.Show(detx.ToString());
                xn = x0 - detx;
              //  MessageBox.Show(xn.ToString());
                fxn = FUNCTIONS.getImage(xn);
               // MessageBox.Show(fxn.ToString());
                tabla.Rows.Add(x0, fx0, fdx0, detx, xn, fxn);

                if (Math.Abs(detx) <= tolerancy)
                {
                    return true;
                }

                x0 = xn;

                cont++;
                if(cont>100000)
                {                    
                    msgbox.error("Desbordamiento!");
                    return true;
                }
            }
                        
        }
        protected Boolean getValueX()
        {
            if(c1.Checked == true)
            {
                try
                {
                    this.a = Double.Parse(textBox1.Text.Trim().Replace('.', ','));
                }
                catch(Exception ex)
                {
                    msgbox.error(ex.ToString());
                    return false;
                }
                
                
                return true;
               
            }
            else if(c2.Checked == true)
            {
                try
                {
                    this.a = Double.Parse(textBox2.Text.Trim().Replace('.', ','));
                }
                catch (Exception ex)
                {
                    msgbox.error(ex.ToString());
                    return false;
                }
               
            }

            try
            {
               this.tolerancy = Double.Parse(this.textBox3.Text.Trim().Replace('.',','));
            }catch(Exception ex)
            {
                msgbox.error(ex.ToString());
                return false;
            }

            return true;
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        protected void c1_CheckedChanged(object sender, EventArgs e)
        {
           if(this.c1.Checked==true)
            {
                if (this.c2.Checked == true)
                    this.c2.Checked = false;

            }

        }

        protected void c2_CheckedChanged(object sender, EventArgs e)
        {
            if(this.c2.Checked==true)
            {
                if (this.c1.Checked == true)
                    this.c1.Checked = false;
            }
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.c1.Checked == true || this.c2.Checked==true)
            {               
                if(this.getValueX())
                {
                    this.setModel();
                    Application.DoEvents();
                    if (this.setRows())
                    {
                        this.dataGridView1.DataSource = this.tabla;
                        int temporal = dataGridView1.Rows.Count;
                        this.dataGridView1.Rows[temporal-1].Cells[4].Style.BackColor = Color.CadetBlue;

                        foreach(DataGridViewRow x in this.dataGridView1.Rows)
                        {
                            x.HeaderCell.Value = (x.Index + 1).ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un valor para X0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
