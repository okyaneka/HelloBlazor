using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace HelloBlazor.App.Components;

public class InputPassword : MudTextField<string>
{
  private bool _showPassword;

  protected override void OnInitialized()
  {
    base.OnInitialized();

    InputType = InputType.Password;

    Adornment = Adornment.End;
    AdornmentIcon = Icons.Material.Filled.Visibility;

    OnAdornmentClick = EventCallback.Factory.Create<MouseEventArgs>(this, TogglePasswordVisibility);
  }

  private void TogglePasswordVisibility(MouseEventArgs args)
  {
    _showPassword = !_showPassword;

    if (_showPassword)
    {
      InputType = InputType.Text;
      AdornmentIcon = Icons.Material.Filled.VisibilityOff;
    }
    else
    {
      InputType = InputType.Password;
      AdornmentIcon = Icons.Material.Filled.Visibility;
    }
  }
}