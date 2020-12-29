using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NestedDialogs.Client.Components;
using NestedDialogs.Shared;
using Radzen;

namespace NestedDialogs.Client.Pages
{
    public partial class Index
    {
        [Inject]
        private DialogService DialogService { get; set; }

        [Inject]
        private NotificationService Notifications { get; set; }


        private async Task EditContactButtonClick()
        {
            Console.WriteLine("In EditContactButtonClick");
            var contactToEdit = new Contact();

            try
            {
                var objAsync = await DialogService.OpenAsync<ContactCreate>(
                    "Edit Contact",
                    new Dictionary<string, object> { { "Contact", contactToEdit } });

                if (!(objAsync is Contact contactToUpdate))
                {
                    Notifications.Notify(NotificationSeverity.Info, "Dialog was cancelled ", duration: 10_000);
                    return; // maybe canceled edit then objAsync has the value true
                }

                Notifications.Notify(NotificationSeverity.Success, $"Contact is {contactToUpdate.Active}", duration: 10_000);
            }
            catch (Exception e)
            {
                Notifications.Notify(NotificationSeverity.Error, "Unable to update the contact, " + e.Message);
            }
        }
    }
}
