namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
        InitializeComponent();
	}


    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuarios> lista_usuarios = new List<DadosUsuarios>()
			{
				new DadosUsuarios()
				{
					Usuario = "jose",
					Senha = "123"
				},
				new DadosUsuarios()
				{
					Usuario = "maria",
					Senha = "321"
				}
			};

			DadosUsuarios dados_digitados = new DadosUsuarios()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text

			};

			// LINQ
			if (lista_usuarios.Any(
				i => (dados_digitados.Usuario == i.Usuario &&
				dados_digitados.Senha == i.Senha)))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();
			}
			else 
			{
				throw new Exception("Usuário ou senha inválido");
            }


		} catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}

    }
}