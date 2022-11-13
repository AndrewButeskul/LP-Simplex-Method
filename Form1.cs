using System.Numerics;

namespace Simplex
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        object[] items = new object[] { 1, 2, 3, 4, 5, 6, 7 };
        int quantityConstraints = 0;
        int quantityVaruables = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxConstrains.Items.AddRange(items);
            comboBoxVariables.Items.AddRange(items);           
            textBoxResult.ReadOnly = true;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(comboBoxConstrains.Text, out quantityConstraints);
                int.TryParse(comboBoxVariables.Text, out quantityVaruables);

                fillConstraints();
                fillFunc();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
          
        }

        void fillFunc()
        {
            dataGridViewFunc.Rows.Clear();
            dataGridViewFunc.ColumnCount = quantityVaruables;
            dataGridViewEquation.RowHeadersVisible = false;

            for (int i = 0; i < quantityVaruables; i++)
            {
                dataGridViewFunc.Columns[i].Width = 50;
                dataGridViewFunc.Columns[i].Name = "X" + (i + 1).ToString();
            }
        }
        void fillConstraints()
        {
            dataGridViewEquation.Rows.Clear();
            dataGridViewEquation.ColumnCount = quantityVaruables + 2;
            dataGridViewEquation.RowHeadersVisible = false;
            dataGridViewEquation.RowCount = quantityConstraints;

            for (int i = 0; i < quantityVaruables + 2; i++)
            {
                dataGridViewEquation.Columns[i].Width = 50;
                if (i < quantityVaruables)
                {
                    dataGridViewEquation.Columns[i].Name = "X" + (i + 1).ToString();
                }
                else if (i == quantityVaruables)
                    dataGridViewEquation.Columns[i].Name = "sign";
                else
                    dataGridViewEquation.Columns[i].Name = "b";
            }

            for (int i = 0; i < quantityConstraints; i++)
            {
                dataGridViewEquation.Rows[i].Cells[quantityVaruables].Value = "=";           
            }            
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            bool findSolution = true;
            Constraint[] constraints = new Constraint[quantityConstraints];
            double[] funcVars = new double[quantityVaruables];
            double[] C = new double[quantityConstraints];
            WriteData(constraints, funcVars, C);

            while (findSolution)
            {
                Calculating(constraints, funcVars, C);

            }

        }

        public void Calculating(Constraint[] constraints, double[] funcVars, double[] C)
        {
            double[][] simplex = new double[constraints.Length][];

            double[] S = new double[funcVars.Length + 1];

            for (int i = 0; i < constraints.Length; i++)
            {
                simplex[i] = new double[funcVars.Length + 1];
                simplex[i][0] = constraints[i].b;

                for (int j = 1; j < funcVars.Length + 1; j++)
                {                    
                    simplex[i][j] = constraints[i].vars[j - 1];
                }
            }

            S = sValue(S, simplex, C, funcVars);

            textBoxResult.Text = S.ToString();
        }

        public double[] sValue(double[] S, double[][] simplex, double[] C, double[] funcVars)
        {
            S[0] = Sum(simplex, C, 0);

            for (int i = 1; i < S.Length; i++)
            {                
                S[i] = Sum(simplex, C, i) - funcVars[i - 1];
            }
            return S;
        }

        double Sum(double[][] simplex, double[] C, int n)
        {
            double sum = 0;
            for (int i = 0; i < simplex.Count(); i++)
            {
                sum += simplex[i][n] * C[i];                
            }
            return sum;
        }
        public void WriteData(Constraint[] constraints, double[] funcVars, double[] C)
        {
            for (int i = 0; i < quantityConstraints; i++)
            {
                double b = double.Parse((string)dataGridViewEquation.Rows[i].Cells[quantityVaruables + 1].Value);
                string sign = (string)dataGridViewEquation.Rows[i].Cells[quantityVaruables].Value;
                double[] vars = new double[quantityVaruables];

                for (int j = 0; j < quantityVaruables; j++)
                {
                    vars[j] = double.Parse((string)dataGridViewEquation.Rows[i].Cells[j].Value);
                    funcVars[j] = double.Parse((string)dataGridViewFunc.Rows[0].Cells[j].Value);

                    if (funcVars[j] == 0)
                        C[i] = funcVars[j];
                }
                constraints[i] = new Constraint(vars, b, sign);

            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewFunc.Columns.Clear();
            dataGridViewEquation.Columns.Clear();
            dataGridViewSimplex.Columns.Clear();
            textBoxResult.Clear();
        }

        
    }
}