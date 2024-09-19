using AspNetCoreTodo.Controllers;
using AspNetCoreTodo.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Helpers
{
    public static class UrlHelperExtensions
    {
        // public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        // {
        //     return urlHelper.Action(
        //         action: nameof(AccountController.ConfirmEmail),
        //         controller: "Account",
        //         values: new { userId, code },
        //         protocol: scheme);
        // }

        // public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        // {
        //     #pragma warning disable CS8603 // Possible null reference return.
        //     return urlHelper.Action(
        //         action: nameof(AccountController.ResetPassword),
        //         controller: "Account",
        //         values: new { userId, code },
        //         protocol: scheme);
        //     #pragma warning restore CS8603 // Possible null reference return.
        // }
        
    }
}
