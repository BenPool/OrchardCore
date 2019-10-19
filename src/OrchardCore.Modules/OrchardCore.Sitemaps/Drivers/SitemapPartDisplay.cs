using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Sitemaps.Models;
using OrchardCore.Sitemaps.ViewModels;

namespace OrchardCore.Sitemaps.Drivers
{
    public class SitemapPartDisplay : ContentPartDisplayDriver<SitemapPart>
    {
        public override IDisplayResult Edit(SitemapPart part)
        {
            return Initialize<SitemapPartViewModel>("SitemapPart_Edit", m => BuildViewModel(m, part))
                .Location("Parts#Seo:5");
        }

        public override async Task<IDisplayResult> UpdateAsync(SitemapPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model,
                Prefix,
                t => t.OverrideSitemapConfig,
                t => t.ChangeFrequency,
                t => t.Exclude,
                t => t.Priority
            );
            return Edit(model);
        }


        private void BuildViewModel(SitemapPartViewModel model, SitemapPart part)
        {
            model.OverrideSitemapSetConfig = part.OverrideSitemapConfig;
            model.ChangeFrequency = part.ChangeFrequency;
            model.Exclude = part.Exclude;
            model.Priority = part.Priority;
            model.SitemapPart = part;
        }
    }
}
