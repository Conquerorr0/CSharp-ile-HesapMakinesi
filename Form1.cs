using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class Form1 : Form
    {

        String values, showValue;
        double conclusion;
        bool isItFirstValue;
        string _operator;

        public Form1()
        {
            InitializeComponent();
            //Uygulama ilk çalıştığında pozisyonunu ekranın ortasına ayarlıyor
            this.StartPosition = FormStartPosition.CenterScreen;
            values = "";
            showValue = "";
            conclusion = 0;
            isItFirstValue = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnC_Click(object sender, EventArgs e)
        {

        }

        private void btnCE_Click(object sender, EventArgs e)
        {

        }

        History history;
        private void btnEq_Click(object sender, EventArgs e)
        {
            calculate();
            history = new History(showValue, Convert.ToString(conclusion));
            history.yaz();
            txtConclusion.Text = Convert.ToString(conclusion);
            txtShow.Text = "";
            //Geçmişe kaydetmek için txt dosyasına showvalues ve conclusion değerlerini göndererek texte kaydetme sınıfında hallet.

        }


        private void action_Click(object sender, EventArgs e)
        {

            if (sender == btnZero && (!values.Equals("")))
            {
                values += "0";
                showValue += "0";
            }
            else if (sender == btnOne)
            {
                values += "1";
                showValue += "1";
            }
            else if (sender == btnTwo)
            {
                values += "2";
                showValue += "2";
            }
            else if (sender == btnThree)
            {
                values += "3";
                showValue += "3";
            }
            else if (sender == btnFour)
            {
                values += "4";
                showValue += "4";
            }
            else if (sender == btnFive)
            {
                values += "5";
                showValue += "5";
            }
            else if (sender == btnSix)
            {
                values += "6";
                showValue += "6";
            }
            else if (sender == btnSeven)
            {
                values += "7";
                showValue += "7";
            }
            else if (sender == btnEight)
            {
                values += "8";
                showValue += "8";
            }
            else if (sender == btnNine)
            {
                values += "9";
                showValue += "9";
            }

            txtShow.Text = showValue;
        }

        //txtShow textBox'ına değer girildiğinde eğer sığmazsa fontu kğ
        private void fontReduction1(object sender, EventArgs e)
        {
            int fontSize = 36;
            Font font = new Font(txtShow.Font.FontFamily, fontSize, txtShow.Font.Style);
            while (TextRenderer.MeasureText(txtShow.Text, font).Width > txtShow.Width || TextRenderer.MeasureText(txtShow.Text, font).Height > txtShow.Height)
            {
                fontSize--;
                font = new Font(txtShow.Font.FontFamily, fontSize, txtShow.Font.Style);
            }
            txtShow.Font = font;
        }


        //Herhangi bir operatöre basıldığında conclusion değişkenine operatöre basılmadan önceki değeri atıyorum.
        //Böylece operatörden sonraki kısmı operatöre göre conclusion değişkenindeki değer ile hesaplayacağım.

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (isItFirstValue)
            {
                conclusion += Convert.ToDouble(values);
                isItFirstValue = false;
            }
            else
            {
                calculate();
            }
            process("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (isItFirstValue)
            {
                conclusion = Convert.ToDouble(values);
                isItFirstValue = false;
            }
            else
            {
                calculate();
            }
            process("-");
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (isItFirstValue)
            {
                conclusion += Convert.ToDouble(values);
                isItFirstValue = false;
            }
            else
            {
                calculate();
            }
            process("x");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (isItFirstValue)
            {
                conclusion += Convert.ToDouble(values);
                isItFirstValue = false;
            }
            else
            {
                calculate();
            }
            process("÷");
        }


        private void process(string symbol)
        {
            values = "";
            _operator = symbol;
            showValue += symbol;
            txtConclusion.Text = conclusion + "";
            txtShow.Text = showValue;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!showValue.Equals(""))
            {
                showValue = showValue.Remove(showValue.Length - 1);
                values = values.Remove(values.Length - 1);
                txtShow.Text = showValue;
            }
        }

        

        private void btnOff_Click(object sender, EventArgs e)
        {
            if (btnOff.Text.Equals("OFF"))
            {
                foreach (Control control in this.Controls)
                {
                    if (control is System.Windows.Forms.Button && !control.Text.Equals("OFF"))
                    {
                        control.Enabled = false;
                    }
                }
                txtShow.Text = "";
                txtConclusion.Text = "";
                btnOff.Text = "ON";
            }
            else
            {
                foreach (Control control in this.Controls)
                {
                    if (control is System.Windows.Forms.Button)
                    {
                        control.Enabled = true;
                    }
                }
                btnOff.Text = "OFF";
            }

        }

        private void btnC_Click_1(object sender, EventArgs e)
        {
            txtConclusion.Text = "";
            txtShow.Text = "";
            values = "";
            showValue = "";
            conclusion = 0;
            isItFirstValue = true;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            history = new History();
            txtConclusion.Text = history.oku();
            //txtConclusion.Text = history.oku();
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Gainsboro)
            {

                // Eğer mevcut tema beyaz ise, siyah tema olarak değiştir.
                Theme2();
            }
            else
            {
                // Eğer mevcut tema siyah ise, beyaz tema olarak değiştir.
                Theme1();
                
            }
        }

        private void calculate()
        {
            switch (_operator)
            {
                case "+":
                    conclusion += Convert.ToDouble(values);
                    break;
                case "-":
                    conclusion -= Convert.ToDouble(values);
                    break;
                case "x":
                    conclusion *= Convert.ToDouble(values);
                    break;
                case "÷":
                    conclusion /= Convert.ToDouble(values);
                    break;
            }
            conclusion = Convert.ToDouble(conclusion.ToString("0.##")); 
        }

        private void Theme1()
        {
            this.BackColor = Color.Gainsboro;
            this.ForeColor = Color.Black;

            //TextBoxlar
            txtConclusion.BackColor = SystemColors.ControlLight;
            txtConclusion.ForeColor = Color.Black;
            txtShow.BackColor = SystemColors.ControlLight;
            txtShow.ForeColor = Color.Black;

            //Rakam butonları
            btnOne.BackColor = Color.Silver;
            btnOne.ForeColor = Color.White;
            btnTwo.BackColor = Color.Silver;
            btnTwo.ForeColor = Color.White;
            btnThree.BackColor = Color.Silver;
            btnThree.ForeColor = Color.White;
            btnFour.BackColor = Color.Silver;
            btnFour.ForeColor = Color.White;
            btnFive.BackColor = Color.Silver;
            btnFive.ForeColor = Color.White;
            btnSix.BackColor = Color.Silver;
            btnSix.ForeColor = Color.White;
            btnSeven.BackColor = Color.Silver;
            btnSeven.ForeColor = Color.White;
            btnEight.BackColor = Color.Silver;
            btnEight.ForeColor = Color.White;
            btnNine.BackColor = Color.Silver;
            btnNine.ForeColor = Color.White;

            //Operatör butonları
            btnPlus.BackColor = SystemColors.GrayText;
            btnPlus.ForeColor = Color.White;
            btnMinus.BackColor = SystemColors.GrayText;
            btnMinus.ForeColor = Color.White;
            btnMulti.BackColor = SystemColors.GrayText;
            btnMulti.ForeColor = Color.White;
            btnDiv.BackColor = SystemColors.GrayText;
            btnDiv.ForeColor = Color.White;

            //Turuncu 
            btnOff.BackColor = Color.DarkOrange;
            btnOff.ForeColor = Color.White;
            btnC.BackColor = Color.DarkOrange;
            btnC.ForeColor = Color.White;
            btnHistory.BackColor = Color.DarkOrange;
            btnHistory.ForeColor = Color.White;
            btnDelete.BackColor = Color.DarkOrange;
            btnDelete.ForeColor = Color.White;

            //Tema ve Eşittir butonları
            btnEq.BackColor = Color.SkyBlue;
            btnEq.ForeColor = Color.White;
            btnThemes.BackColor = Color.SkyBlue;
            btnThemes.ForeColor = Color.White;

        }

        private void Theme2()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            //TextBoxlar
            txtConclusion.BackColor = SystemColors.ControlDark;
            txtConclusion.ForeColor = Color.White;
            txtShow.BackColor = SystemColors.ControlDark;
            txtShow.ForeColor = Color.White;

            //Rakam butonları
            btnOne.BackColor = Color.DimGray;
            btnOne.ForeColor = Color.White;
            btnTwo.BackColor = Color.DimGray;
            btnTwo.ForeColor = Color.White;
            btnThree.BackColor = Color.DimGray;
            btnThree.ForeColor = Color.White;
            btnFour.BackColor = Color.DimGray;
            btnFour.ForeColor = Color.White;
            btnFive.BackColor = Color.DimGray;
            btnFive.ForeColor = Color.White;
            btnSix.BackColor = Color.DimGray;
            btnSix.ForeColor = Color.White;
            btnSeven.BackColor = Color.DimGray;
            btnSeven.ForeColor = Color.White;
            btnEight.BackColor = Color.DimGray;
            btnEight.ForeColor = Color.White;
            btnNine.BackColor = Color.DimGray;
            btnNine.ForeColor = Color.White;

            //Operatör butonları
            btnPlus.BackColor = SystemColors.InfoText;
            btnPlus.ForeColor = Color.White;
            btnMinus.BackColor = SystemColors.InfoText;
            btnMinus.ForeColor = Color.White;
            btnMulti.BackColor = SystemColors.InfoText;
            btnMulti.ForeColor = Color.White;
            btnDiv.BackColor = SystemColors.InfoText;
            btnDiv.ForeColor = Color.White;

            //Turuncu 
            btnOff.BackColor = Color.OrangeRed;
            btnOff.ForeColor = Color.White;
            btnC.BackColor = Color.OrangeRed;
            btnC.ForeColor = Color.White;
            btnHistory.BackColor = Color.OrangeRed;
            btnHistory.ForeColor = Color.White;
            btnDelete.BackColor = Color.OrangeRed;
            btnDelete.ForeColor = Color.White;

            //Tema ve Eşittir butonları
            btnEq.BackColor = Color.DarkCyan;
            btnEq.ForeColor = Color.White;
            btnThemes.BackColor = Color.DarkCyan;
            btnThemes.ForeColor = Color.White;
        }
    }
}
