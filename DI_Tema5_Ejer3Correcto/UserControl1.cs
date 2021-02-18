using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema5_Ejer3Correcto
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        /**
         * =============================================================================
            ____ ____ ____ ____ ____    ___  ____ ____ ___  _ ____ ___  ____ ___  ____ ____ 
            |    |__/ |___ |__| |__/    |__] |__/ |  | |__] | |___ |  \ |__| |  \ |___ [__  
            |___ |  \ |___ |  | |  \    |    |  \ |__| |    | |___ |__/ |  | |__/ |___ ___]
         * =============================================================================
         * 
         * https://www.flaticon.es/icono-gratis/punta-de-flecha-del-boton-de-reproduccion_27223
         * https://www.flaticon.es/icono-gratis/pausa_151859?term=pause&page=1&position=2&page=1&position=2&related_id=151859&origin=search
        */

        //PausePlay**************************************
        private bool pausePlay = true; //true = pause
        [Category("aparienciaNueva")]
        [Description("Pone el componente en pause o en play")]
        public bool PausePlay
        {
            set
            {
                pausePlay = value;
                button1.Image = value ? Properties.Resources.pause : Properties.Resources.play;
            }
            get
            {
                return pausePlay;
            }

        }

        //XX ******************************************
        private int xx;
        [Category("aparienciaNueva")]
        [Description("Valor entre 0 y 99")]
        public int Xx
        {
            set
            {
                if (value > 99 || value < 0)
                {
                    xx = 0;
                }
                else
                {
                    xx = value;
                }
                Recolocar();

            }
            get
            {
                return xx;
            }
        }

        //YY ******************************************
        private int yy;
        [Category("aparienciaNueva")]
        [Description("Valor entre 0 y 59")]
        public int Yy
        {
            set
            {
                if (value > 59)
                {
                    yy = value % 60;
                    DesbordaTiempo?.Invoke(this, EventArgs.Empty);

                }
                else if (value < 0)
                {
                    yy = 0;
                }
                else
                {
                    yy = value;
                }
                Recolocar();
            }
            get
            {
                return yy;
            }
        }


        /**
     * =============================================================================
               _    ____ _  _ ___  ____ ____    ____ _  _ ____ _  _ ___ ____ ____ 
               |    |__| |\ |   /  |__| |__/    |___ |  | |___ |\ |  |  |  | [__  
               |___ |  | | \|  /__ |  | |  \    |___  \/  |___ | \|  |  |__| ___]
     * =============================================================================
    */
        [Category("click en pausePlay")]
        [Description("cambia entre play y pause")]
        public event System.EventHandler ClickEnPuse;

        //protected override void OnClick(EventArgs e) //esto es el del componente, no el del boton de dentro del componente
        //{
        //    ClickEnPuse?.Invoke(this,EventArgs.Empty);
        //    base.OnClick(e);
        //}

        [Category("Desborda tiempo")]
        [Description("Cuando YY es mayor de 59")]
        public event System.EventHandler DesbordaTiempo;

        private void Recolocar()
        {
            label1.Text = string.Format("{0:00}:{1:00}", xx,yy);
        }

        private void click(object sender, EventArgs e) // este es el correcto
        {
            ClickEnPuse?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
        }
    }


}
