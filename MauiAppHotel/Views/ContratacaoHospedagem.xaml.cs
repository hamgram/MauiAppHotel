using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto { Nome = "Suite Master", ValorAdultos = 225.5, ValorCriancas = 200.3 },
        new Quarto { Nome = "Suite Luxo", ValorAdultos = 200.5, ValorCriancas = 180.3 },
        new Quarto { Nome = "Suite Standard", ValorAdultos = 150.5, ValorCriancas = 130.3 },
        new Quarto { Nome = "Suite Lite", ValorAdultos = 98.80, ValorCriancas = 80.00 },

    };


	public ContratacaoHospedagem()
	{
		InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(3);


        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(4);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.Sobre();

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {

            Hospedagem h = new()
            {
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                QuartoEscolhido = (Quarto) pck_quarto.SelectedItem,
                DataCheckin = dtpck_checkin.Date.Value,
                DataCheckout = dtpck_checkout.Date.Value,
            };

            Navigation.PushAsync(new HospedagemContratada
            {

                BindingContext = h

            });

        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "OK");
        }
    }
}