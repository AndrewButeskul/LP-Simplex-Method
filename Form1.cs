using System.Numerics;
using System.Xml.Schema;

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
        int quantityVariables = 0;
        bool findSolution = false;
        double result = 0;
        int iteration = 0;
        int directColumn, directRow;
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
                int.TryParse(comboBoxVariables.Text, out quantityVariables);

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
            dataGridViewFunc.ColumnCount = quantityVariables;
            dataGridViewEquation.RowHeadersVisible = false;

            for (int i = 0; i < quantityVariables; i++)
            {
                dataGridViewFunc.Columns[i].Width = 50;
                dataGridViewFunc.Columns[i].Name = "X" + (i + 1).ToString();
            }
        }
        void fillConstraints()
        {
            dataGridViewEquation.Rows.Clear();
            dataGridViewEquation.ColumnCount = quantityVariables + 2;
            dataGridViewEquation.RowHeadersVisible = false;
            dataGridViewEquation.RowCount = quantityConstraints;

            for (int i = 0; i < quantityVariables + 2; i++)
            {
                dataGridViewEquation.Columns[i].Width = 50;
                if (i < quantityVariables)
                {
                    dataGridViewEquation.Columns[i].Name = "X" + (i + 1).ToString();
                }
                else if (i == quantityVariables)
                    dataGridViewEquation.Columns[i].Name = "sign";
                else
                    dataGridViewEquation.Columns[i].Name = "b";
            }

            for (int i = 0; i < quantityConstraints; i++)
            {
                dataGridViewEquation.Rows[i].Cells[quantityVariables].Value = "=";
            }
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            Constraint[] constraints = new Constraint[quantityConstraints];
            double[] funcVars = new double[quantityVariables];
            Basis[] C = new Basis[quantityConstraints];

            ReadData(constraints, funcVars, C);

            dataGridViewSimplex.RowHeadersVisible = false;
            dataGridViewSimplex.ColumnCount = quantityVariables + 3;
            for (int i = 0; i < quantityVariables + 3; i++)
            {
                dataGridViewSimplex.Columns[i].Width = 50;
            }

            while (!findSolution)
            {
                Calculating(constraints, funcVars, C);
                iteration++;
            }

            textBoxResult.Text = result == (-0.1) ? "There isn't a solution!" : result.ToString();
        }

        public void Calculating(Constraint[] constraints, double[] funcVars, Basis[] C)
        {
            double[][] simplex = new double[quantityConstraints][];
            double[] S = new double[funcVars.Length + 1];

            if (iteration == 0)
            {
                CopySimplex(constraints, simplex);
                S = sValue(S, simplex, C, funcVars);
                result = Math.Round(S[0], 2);
                ReWriteTable(simplex, funcVars, C, S);
                FindDirectColumn(S);
                directRow = FindDirectRow(constraints);
                ReplaceBasis(C, funcVars);
            }
            else
            {
                simplex = CalculateOfElements(constraints, simplex);
                S = sValue(S, simplex, C, funcVars);
                result = Math.Round(S[0], 2);
                ReWriteTable(simplex, funcVars, C, S);
                FindDirectColumn(S);

                if (!findSolution)
                {
                    directRow = FindDirectRow(constraints);
                    ReplaceBasis(C, funcVars);
                    CopySimplex(simplex, constraints);
                }                
            }
        }

        public double[][] CalculateOfElements(Constraint[] constraints, double[][] simplex)
        {
            double[][] simplexApend = new double[quantityConstraints][];
            CopySimplex(constraints, simplexApend);

            for (int i = 0; i < quantityConstraints; i++)
            {
                simplex[i] = new double[quantityVariables + 1];

                for (int j = 0; j < quantityVariables + 1; j++)
                {
                    if (i == directRow && j == directColumn)
                        simplex[i][j] = 1;
                    if (i == directRow && j != directColumn)
                        simplex[i][j] = simplexApend[i][j] / simplexApend[directRow][directColumn];

                    if (j == directColumn && i != directRow)
                        simplex[i][j] = 0;
                    if (i != directRow && j != directColumn)
                        simplex[i][j] = simplexApend[i][j] - (simplexApend[i][directColumn] *
                            simplexApend[directRow][j] / simplexApend[directRow][directColumn]);

                    /*for (int j = 0; j < simplex.First().Length; j++)
                    {
                        if (i == directRow && j == directColumn)
                            simplex[i][j] = 1;
                        if (i == directRow && j != directColumn)
                        {
                            simplex[i][j] = constraints[i].vars[j] / constraints[directRow].vars[directColumn];
                            //simplex[i][0] = constraints[i].b / constraints[directRow].vars[directColumn];
                        }

                        if (j == directColumn && i != directRow)
                            simplex[i][j] = 0;
                        if (i != directRow && j != directColumn)
                            simplex[i][j] = constraints[i].vars[j] - (constraints[i].vars[directColumn] *
                                constraints[directRow].vars[j] / constraints[directRow].vars[directColumn]);*/
                }
            }
            return simplex;
        }
        public void FindDirectColumn(double[] S)
        {
            for (int i = 1; i < S.Length; i++)
            {
                if (S.Min() == S[i] && S.Min() < 0)
                {
                    directColumn = i;
                    break;
                }
                else if (S.Min() == 0)
                {
                    findSolution = true;
                    result = Math.Round(S[0], 2);
                    break;
                }
                else if (S.Min() > 0)
                {
                    findSolution = true;
                    result = -0.1;
                    break;
                }
            }
        }
        public void ReplaceBasis(Basis[] C, double[] funcVars)
        {
            C[directRow].C = funcVars[directColumn - 1];
            C[directRow].Index = directColumn;
        }
        public int FindDirectRow(Constraint[] constraints)
        {
            int index = 0;
            double value = 0;
            double temp = double.MaxValue;
            for (int i = 0; i < constraints.Count(); i++)
            {
                if (constraints[i].vars[directColumn - 1] < 0)
                    continue;

                value = constraints[i].b / constraints[i].vars[directColumn - 1];
                if (value < temp && value > 0)
                {
                    temp = value;
                    index = i;
                }
            }
            return index;
        }
        public void CopySimplex(Constraint[] constraints, double[][] simplex)
        {
            for (int i = 0; i < constraints.Length; i++)
            {
                simplex[i] = new double[quantityVariables + 1];
                simplex[i][0] = constraints[i].b;

                for (int j = 1; j < quantityVariables + 1; j++)
                {
                    simplex[i][j] = constraints[i].vars[j - 1];
                }
            }
        }

        public void CopySimplex(double[][] simplex, Constraint[] constraints)
        {
            for (int i = 0; i < quantityConstraints; i++)
            {
                constraints[i].b = simplex[i][0];
                for (int j = 0; j < quantityVariables; j++)
                {
                    constraints[i].vars[j] = simplex[i][j + 1];
                }
            }
        }

        public void ReWriteTable(double[][] simplex, double[] funcVars, Basis[] C, double[] S)
        {
            
            string[] firstRow = new string[quantityVariables + 3];
            firstRow[0] = "C";
            firstRow[1] = "Xp";
            firstRow[2] = "B";
            for (int i = 3; i < quantityVariables + 3; i++)
            {
                firstRow[i] = $"A{i - 2}";
            }
            dataGridViewSimplex.Rows.Add(firstRow);

            for (int i = 1; i < simplex.Count() + 1; i++)
            {
                string[] tempRow = new string[quantityVariables + 3];
                for (int j = 0; j < quantityVariables + 3; j++)
                {
                    if (j == 0)
                        tempRow[j] = C[i - 1].C.ToString();

                    else if (j == 1)
                        tempRow[j] = $"X{C[i - 1].Index + 1}";
                    else
                        tempRow[j] = Math.Round(simplex[i - 1][j - 2], 2).ToString();
                }
                dataGridViewSimplex.Rows.Add(tempRow);
            }

            string[] SRow = new string[quantityVariables + 3];
            SRow[0] = "S";
            SRow[1] = "";
            for (int i = 2; i < SRow.Length; i++)
            {
                SRow[i] = Math.Round(S[i - 2], 2).ToString();
            }
            dataGridViewSimplex.Rows.Add(S);

        }

        public double[] sValue(double[] S, double[][] simplex, Basis[] C, double[] funcVars)
        {
            S[0] = Sum(simplex, C, 0);

            for (int i = 1; i < S.Length; i++)
            {
                S[i] = Sum(simplex, C, i) - funcVars[i - 1];
            }
            return S;
        }

        double Sum(double[][] simplex, Basis[] C, int n)
        {
            double sum = 0;
            for (int i = 0; i < simplex.Count(); i++)
            {
                sum += simplex[i][n] * C[i].C;
            }
            return sum;
        }
        public void ReadData(Constraint[] constraints, double[] funcVars, Basis[] C)
        {

            for (int i = 0; i < quantityConstraints; i++)
            {
                double b = double.Parse((string)dataGridViewEquation.Rows[i].Cells[quantityVariables + 1].Value);
                string sign = (string)dataGridViewEquation.Rows[i].Cells[quantityVariables].Value;
                double[] vars = new double[quantityVariables];

                for (int j = 0; j < quantityVariables; j++)
                {
                    vars[j] = double.Parse((string)dataGridViewEquation.Rows[i].Cells[j].Value);
                    funcVars[j] = double.Parse((string)dataGridViewFunc.Rows[0].Cells[j].Value);

                    if (funcVars[j] == 0)
                    {
                        C[i] = new Basis(funcVars[j], j);
                    }
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