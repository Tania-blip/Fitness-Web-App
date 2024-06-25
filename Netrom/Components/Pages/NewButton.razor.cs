using Microsoft.AspNetCore.Components;

namespace Netrom.Components.Pages
{
    public partial class NewButton : ComponentBase
    {
        [Parameter]
        public int currentCount {  get; set; }

    }
}
