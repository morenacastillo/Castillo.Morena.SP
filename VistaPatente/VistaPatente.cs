using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Patentes

{
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);
    public delegate void MostrarPatente(object patente);


    public partial class VistaPatente : UserControl
    {
        public event FinExposicionPatente finExposicion;

        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)Tipo.Mercosur];
        }

        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    lblPatenteNro.Invoke(new Action(() =>
                    {
                        picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                        lblPatenteNro.Text = patente.ToString();
                    }));

                    Thread.Sleep(1500);

                    finExposicion?.Invoke(this);

                    Thread.Sleep(1500);
                }
                catch (Exception) { }
            }
            else
            {
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();

                Thread.Sleep(1500);
                finExposicion?.Invoke(this);
            }
        }
    }
}
