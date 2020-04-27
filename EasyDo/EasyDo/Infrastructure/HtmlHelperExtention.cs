
namespace EasyDo.Infrastructure
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    
    public static class HtmlHelperExtention
    {
        public static HtmlString SubmitSave<TModel>(this IHtmlHelper<TModel> helper, string value)
        {
            return new HtmlString($"<button class='genric-btn primary circle arrow borderBtn float-right' type='submit' value='{value}'>Save</button>");
        }
        public static HtmlString SubmitSend<TModel>(this IHtmlHelper<TModel> helper, string value)
        {
            return new HtmlString($"<button class='genric-btn primary circle arrow borderBtn float-right send' type='submit' value='{value}'>Send</button>");
        }
        public static HtmlString SubmitDelete<TModel>(this IHtmlHelper<TModel> helper, string value)
        {
            return new HtmlString($"<button class='btn genric-btn danger circle arrow borderBtn float-right' type='submit' value='{value}'>Delete</button>");
        }

        public static HtmlString Back<TModel>(this IHtmlHelper<TModel> helper, string value)
        {
            return new HtmlString($"<button class='genric-btn success circle arrow float-right borderBtn' onClick='window.history.back(); return false;'>Back</button>");
        }
    }
}
