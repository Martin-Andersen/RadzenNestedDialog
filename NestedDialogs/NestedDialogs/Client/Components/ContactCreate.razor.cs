using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NestedDialogs.Shared;
using Radzen;

namespace NestedDialogs.Client.Components
{
    public partial class ContactCreate
    {
        [Inject]
        private DialogService DialogService { get; set; }

        [Parameter]
        public Contact Contact { get; set; } = new Contact();

        private async Task InactivateContactButtonClicked()
        {
            if (await DialogService.Confirm("Setting a contact inactive will also remove all reports for that contact. ", "Inactivate Contact?") == false)
            {
                return;
            }
            Contact.Active = false;
            DialogService.Close(Contact);
        }
        
        private void HandleValidSubmit()
        {
            DialogService.Close(Contact);
        }
    }
}
