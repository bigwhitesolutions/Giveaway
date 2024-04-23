using Google.Apis.Auth.OAuth2;
using Google.Apis.Forms.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MudBlazor;

namespace Giveaway.BusinessLogic.GiveawayEntrySources;

public class GoogleFormsGiveawayEntryProvider(string clientId, string clientSecret, string formId)
    : IGiveawayEntriesProvider
{
    public async Task<IList<GiveawayEntry>> GetEntries()
    {
        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
            new[] { FormsService.Scope.FormsResponsesReadonly },
            "user",
            CancellationToken.None,
            new FileDataStore("Form.GiveawayEntry"));


        var api = new FormsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Giveaway"
        });
        var responses = await api.Forms.Responses.List(formId).ExecuteAsync();
        return responses.Responses.Select(x => new BusinessLogic.GiveawayEntry
            {
                Name = x.Answers.First().Value.TextAnswers.Answers[0].Value,
                Email = x.RespondentEmail,
                Style = $"background-color: {Colors.Amber.Default};color: {Colors.Shades.Black}"
            }
        ).ToList();
    }
}