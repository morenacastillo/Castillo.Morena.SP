using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Archivo;
using System.Threading;

namespace Formulario
{
    /// <summary>
    /// Formulario principal para la gestión de patentes.
    /// </summary>
    public partial class FrmPricipal : Form
    {
        List<Patente> patentes;
        List<Thread> hilos;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmPricipal"/>.
        /// </summary>
        public FrmPricipal()
        {
            InitializeComponent();
            patentes = new List<Patente>();
        }

        /// <summary>
        /// Manejador del evento Load del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_Load(object sender, EventArgs e)
        {
            vistaPatente.finExposicion += ProximaPatente;
        }

        /// <summary>
        /// Manejador del evento FormClosing del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarSimulacion();
        }

        /// <summary>
        /// Manejador del evento Click del botón para agregar más patentes.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                List<Patente> listPatente = new List<Patente>
                {
                    new Patente("CP709WA", Tipo.Mercosur),
                    new Patente("DIB009", Tipo.Vieja),
                    new Patente("FD010GC", Tipo.Mercosur)
                };

                Sql sql = new Sql();
                Xml xml = new Xml();
                Texto txt = new Texto();

                if (sql.Guardar(listPatente))
                {
                    MessageBox.Show("¡Patentes guardadas en la base de datos!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en la base de datos!");
                }

                if (xml.Guardar(listPatente))
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo XML!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo XML!");
                }

                if (txt.Guardar(listPatente))
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde la base de datos SQL.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sql = new Sql();
                patentes = sql.Leer();
                if (patentes != null)
                {
                    patentes.AddRange(patentes);
                    IniciarSimulacion();
                }
                else
                {
                    MessageBox.Show("No se pudieron leer las patentes desde el archivo SQL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                Xml xml = new Xml();
                patentes = xml.Leer();
                if (patentes != null)
                {
                    patentes.AddRange(patentes);
                    IniciarSimulacion();
                }
                else
                {
                    MessageBox.Show("No se pudieron leer las patentes desde el archivo XML");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                Texto txt = new Texto();
                patentes = txt.Leer();
                if (patentes != null)
                {
                    patentes.AddRange(patentes);
                    IniciarSimulacion();
                }
                else
                {
                    MessageBox.Show("No se pudieron leer las patentes desde el archivo TXT");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Inicia la simulación de visualización de patentes.
        /// </summary>
        private void IniciarSimulacion()
        {
            FinalizarSimulacion();
            
            ProximaPatente(vistaPatente);
            
        }

        /// <summary>
        /// finaliza todos los hilos activos
        /// </summary>
        private void FinalizarSimulacion()
        {
           if (hilos != null)
            {
                foreach (var hilo in hilos)
                {
                    if (hilo.IsAlive)
                    {
                        hilo.Abort();
                    }
                }
                hilos.Clear();
           }
        }


        /// <summary>
        /// Muestra la próxima patente en la vista.
        /// </summary>
        /// <param name="vistaPatente">La vista de la patente.</param>
        private void ProximaPatente(Patentes.VistaPatente vistaPatente)
        {
            if (hilos != null)
            {
                if (patentes.Count > 0)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(vistaPatente.MostrarPatente));
                    thread.Start(patentes.First());
                    hilos.Add(thread);
                    patentes.RemoveAt(0);
                }
            }
               
        }
    }
}
