using System.Windows.Forms;

namespace arreglos_de_todos_los_tipos_from
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Buscador_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Crear el cuadro de diálogo de archivo
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo de texto";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                try
                {
                    string[] lineas = File.ReadAllLines(rutaArchivo);
                    int filas = lineas.Length;
                    int columnas = lineas[0].Split('\t').Length;

                    string[,] datos = new string[filas, columnas];

                    for (int i = 0; i < filas; i++)
                    {
                        string[] valores = lineas[i].Split('\t');
                        for (int j = 0; j < columnas; j++)
                        {
                            datos[i, j] = valores[j];
                        }
                    }

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    for (int j = 0; j < columnas; j++)
                    {
                        dataGridView1.Columns.Add("Columna" + j, "Columna " + j);
                    }

                    for (int i = 0; i < filas; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < columnas; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = datos[i, j];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}