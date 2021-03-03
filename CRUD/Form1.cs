using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Connector();
            MessageBox.Show("Me conecte a la base de datos");
            dataGridView1.DataSource = completar_grid();
           
        }
        //Llamar los datos y monstrar en el grind
        public DataTable completar_grid()
        {
            Conexion.Connector();
            DataTable tabla = new DataTable();
            string consulta = "SELECT * FROM ALUMNO";
            SqlCommand comando = new SqlCommand(consulta, Conexion.Connector());

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(tabla);
            return tabla;
        }

        //Boton insertar
        private void Insertar_Click(object sender, EventArgs e)
        {

            Conexion.Connector();
            string cadena = "INSERT INTO ALUMNO (CODIGO,NOMBRES,APELLIDOS,DIRECCION) VALUES ('"+textID.Text+ "','" + textNombre.Text + "','" + textApellido.Text + "','" + textDireccion.Text + "')";
            SqlCommand comando = new SqlCommand(cadena, Conexion.Connector());
            comando.ExecuteNonQuery();
            MessageBox.Show("La persona: "+textNombre.Text+" se agregado correctamente");
            textID.Clear();
            textNombre.Clear();
            textApellido.Clear();
            textDireccion.Clear();
            dataGridView1.DataSource = completar_grid();
            

        }
        //Boton Eliminar
        private void Eliminar_Click(object sender, EventArgs e)
        {
            Conexion.Connector();
            string cadena = "DELETE FROM ALUMNO WHERE CODIGO='" + textID.Text + "'";
            SqlCommand comando = new SqlCommand(cadena, Conexion.Connector());
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("La persona con el ID " + textID.Text + " se borro correctamente");
                textID.Clear();
                dataGridView1.DataSource = completar_grid();
            }
            else {
                MessageBox.Show("La persona: " + textID.Text + " No se encontro en la base de datos");
            }



        }
        //Boton modificar
        private void Modificar_Click(object sender, EventArgs e)
        {
            Conexion.Connector();
            string cadena = "UPDATE ALUMNO SET NOMBRES='"+textNombre.Text+ "',APELLIDOS='"+textApellido.Text+"', DIRECCION='"+textDireccion.Text+"' WHERE CODIGO='" + textID.Text + "'";
            SqlCommand comando = new SqlCommand(cadena, Conexion.Connector());
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("La persona fue modificada correctamente");
                textID.Clear();
                textNombre.Clear();
                textApellido.Clear();
                textDireccion.Clear();
                dataGridView1.DataSource = completar_grid();
            }
            else
            {
                MessageBox.Show("La persona no se pudo encontro en la base de datos");
            }

        }
        //Boton buscar
        private void Buscar_Click(object sender, EventArgs e)
        {
            
                Conexion.Connector();
                DataTable tabla = new DataTable();
                string cadena = " select * from ALUMNO WHERE CODIGO='" + textID.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, Conexion.Connector());
                comando.ExecuteNonQuery();
                textID.Clear();
                textNombre.Clear();
                textApellido.Clear();
                textDireccion.Clear();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
 

        }
        //boton atualizar
        private void Actualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = completar_grid();
            MessageBox.Show("La tabla su fue actualizada con exito");
        }
    }
}
