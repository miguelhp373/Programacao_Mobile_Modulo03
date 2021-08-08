using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Calculadora
{
    public partial class MainPage : ContentPage
    {
       string operacao = null, exibir_visor = "";
       double memoria_pre = 0.0;
       double memoria_pos = 0.0;
       bool exibe_ponto = true;
    private void Num0(object sender, EventArgs e)
    {
        exibir_visor += btn0.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num1(object sender, EventArgs e)
    {
        exibir_visor += btn1.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num2(object sender, EventArgs e)
    {
        exibir_visor += btn2.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num3(object sender, EventArgs e)
    {
        exibir_visor += btn3.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num4(object sender, EventArgs e)
    {
        exibir_visor += btn4.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num5(object sender, EventArgs e)
    {
        exibir_visor += btn5.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num6(object sender, EventArgs e)
    {
        exibir_visor += btn6.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num7(object sender, EventArgs e)
    {
        exibir_visor += btn7.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num8(object sender, EventArgs e)
    {
        exibir_visor += btn8.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Num9(object sender, EventArgs e)
    {
        exibir_visor += btn9.Text;
        lblVisor.Text = exibir_visor;
    }
    private void Ponto(object sender, EventArgs e)
    {
        if (exibe_ponto)
        {
            exibir_visor += btnPonto.Text;
            lblVisor.Text = exibir_visor;
            exibe_ponto = false;
        }
    }
    private void Limpar(object sender, EventArgs e)
    {
        exibe_ponto = true;
        lblVisor.Text = "0";
        exibir_visor = "";
        memoria_pre = 0;
        memoria_pos = 0;
        operacao = null;
    }
    private void MaisMenos(object sender, EventArgs e)
    {
        try
        {
            double valor_visor = Convert.ToDouble(lblVisor.Text);
            valor_visor *= -1; //valor_visor = valor_visor * -1
            lblVisor.Text = valor_visor.ToString();
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Porcentagem(object sender, EventArgs e)
    {
        try
        {
            double valor_visor = Convert.ToDouble(lblVisor.Text);
            valor_visor = valor_visor / 100;
            lblVisor.Text = valor_visor.ToString();
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Somar(object sender, EventArgs e)
    {
        try
        {
            exibir_visor = "";
            exibe_ponto = true;
            memoria_pre = Convert.ToDouble(lblVisor.Text);
            operacao = "+";
            lblVisor.Text = "";
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Subtrair(object sender, EventArgs e)
    {
        try
        {
            exibir_visor = "";
            exibe_ponto = true;
            memoria_pre = Convert.ToDouble(lblVisor.Text);
            operacao = "-";
            lblVisor.Text = "";
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Multiplicar(object sender, EventArgs e)
    {
        try
        {
            exibir_visor = "";
            exibe_ponto = true;
            memoria_pre = Convert.ToDouble(lblVisor.Text);
            operacao = "*";
            lblVisor.Text = "";
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Dividir(object sender, EventArgs e)
    {
        try
        {
            exibir_visor = "";
            exibe_ponto = true;
            memoria_pre = Convert.ToDouble(lblVisor.Text);
            operacao = "/";
            lblVisor.Text = "";
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    private void Igual(object sender, EventArgs e)
    {
        try
        {
            memoria_pos = Convert.ToDouble(lblVisor.Text);
            double resultado = 0;
            switch (operacao)
            {
                case "+":
                    resultado = memoria_pre + memoria_pos;
                    break;
                case "-":
                    resultado = memoria_pre - memoria_pos;
                    break;
                case "*":
                    resultado = memoria_pre * memoria_pos;
                    break;
                case "/":
                    resultado = memoria_pre / memoria_pos;
                    break;
            }
            lblVisor.Text = resultado.ToString();
        }
        catch (Exception ex)
        {
            lblVisor.Text = ex.Message;
        }
    }
    public MainPage()
    {
        InitializeComponent();
    }
}
}    
}
}
