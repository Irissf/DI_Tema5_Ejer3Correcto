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
                Refresh();

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
                this.Refresh();
            }
            get
            {
                return yy;
            }
        }

        /**
     * =============================================================================
        ___  ____ ____ ___  _ ____ ___  ____ ___  ____ ____    ___  _  _ ___  _    _ ____ ____ ____ 
        |__] |__/ |  | |__] | |___ |  \ |__| |  \ |___ [__     |__] |  | |__] |    | |    |__| [__  
        |    |  \ |__| |    | |___ |__/ |  | |__/ |___ ___]    |    |__| |__] |___ | |___ |  | ___]
     * =============================================================================
    */


        //Propiedades públicas que dan acceso a las propiedades que por defecto estan privadas
        //pero que queremos que puedan acceder a ellas por ejemplo la propiedad Text
        //De quererlo, tendríamos que hacer lo mismo para color, font, size etc.
        [Category("Appearance")]
        [Description("Texto asociado a la label del control")]
        public string TextLbl
        {
            set
            {
                label1.Text = value;
            }
            get
            {
                return label1.Text;
            }
        }

        private void EscribirLabel()
        {
            label1.Text = String.Format("{0:00}:{1:00}", xx, yy);
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

        protected override void OnClick(EventArgs e)
        {
            ClickEnPuse?.Invoke(this,EventArgs.Empty);
            base.OnClick(e);
        }

        [Category("Desborda tiempo")]
        [Description("Cuando YY es mayor de 59")]
        public event System.EventHandler DesbordaTiempo;

    }
}
