using Microsoft.JScript;
using Microsoft.JScript.Vsa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;




namespace MetodosNumericos
{
    public partial class biseccioni : Form
    {
       public DataTable tabla;
       public double a, b, fa, fb, xn, fxn, tolerancy;
       
        private void button1_Click(object sender, EventArgs e)
        {


            if (!getValues())
                return;
            this.createTable();
            this.setRows();
            this.dataGridView1.DataSource = this.tabla;  
            
            foreach(DataGridViewRow x in dataGridView1.Rows)
            {
                x.HeaderCell.Value = (x.Index + 1).ToString();
            }
        }
        public bool getValues()
        {
            textBox1.Text = textBox1.Text.Replace('.', ',');
            textBox2.Text = textBox2.Text.Replace('.', ',');
            textBox3.Text = textBox3.Text.Replace('.', ',');
            try
            {
                this.a = Double.Parse(textBox1.Text.Trim());
                this.b = Double.Parse(textBox2.Text.Trim());
                this.tolerancy = Double.Parse(textBox3.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public biseccioni()
        {
            InitializeComponent();
            this.Text = "Biseccion de Intervalo";
            this.StartPosition = FormStartPosition.CenterScreen;                        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void createTable()
        {
            this.tabla = new DataTable();
            tabla.Columns.Add("A", typeof(double));
            tabla.Columns.Add("B", typeof(double));
            tabla.Columns.Add("C", typeof(double));
            tabla.Columns.Add("Xn", typeof(double));
            tabla.Columns.Add("F(Xn)", typeof(double));
            tabla.Columns.Add("Tolerancia", typeof(string));                 
        }
        
        private bool setRows()
        {
            bool flag = false;
            double c = 0;
            string ttol;

            fa = FUNCTIONS.getImage(a);
            fb = FUNCTIONS.getImage(b);
          

            if (!((fa < 0 && fb > 0) || (fb < 0 && fa > 0)))
            {
                MessageBox.Show("No existe cambio de signo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
                return flag;
            }

           
                while (true)
                {
                    c = (b - a) / 2;


                    xn = a + c;
                    fxn = FUNCTIONS.getImage(xn);

                    if (Math.Abs(c) <= tolerancy)
                    {
                        ttol = "CUMPLIDA";
                        flag = true;
                    }
                    else
                        ttol = "NO CUMPLIDA";

                    try
                    {
                        this.tabla.Rows.Add(a, b, c, xn, fxn, ttol);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    asignLimits(fxn);

                    if (flag)
                        break;                    
            }
          
            return flag;
        }

        public void asignLimits(double Fxn)
        {
            if(Fxn > 0)
            {
                if (fa > 0)
                    a = xn;
                if (fb > 0)
                    b = xn;
            }

            if(Fxn < 0)
            {
                if (fa < 0)
                    a = xn;
                if (fb < 0)
                    b = xn;
            }
        }
           
        

        private string EvalExpression(string expression)
          {
              VsaEngine engine = VsaEngine.CreateEngine();
              try
              {
                  object o = Eval.JScriptEvaluate(expression, engine);
                  return System.Convert.ToDouble(o).ToString();
              }
              catch
              {
                  return "No se puede evaluar la expresión";
              }

              engine.Close();
          }
          
    }   
}


 

       
      