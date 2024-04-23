using System.Diagnostics.CodeAnalysis;
using MudBlazor;

namespace Giveaway.BusinessLogic;

public class GiveawayEntry
{
    private string _style;
    public bool Selected { get; set; } = false;
    public string? Prize { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public required string Style
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(Prize))
            {
                return $"background-color: {Colors.Grey.Darken1};color: {Colors.Shades.White}";
            }

            if (Selected)
            {
                return $"background-color: {Colors.Grey.Darken1};color: {Colors.Shades.White}";
            }

            return _style;
        }
        [MemberNotNull(nameof(_style))] set => _style = value;
    }
}