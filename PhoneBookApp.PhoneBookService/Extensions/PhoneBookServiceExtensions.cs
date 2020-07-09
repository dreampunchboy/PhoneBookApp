using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PhoneBookApp.Interfaces;
using PhoneBookApp.Models.Phone.Database;
using PhoneBookApp.Services.Interfaces;
using PhoneBookApp.Services.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PhoneBookServiceExtensions
    {
        public static IServiceCollection AddPhoneBookService(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure mongo config
            services.Configure<PhoneBookCollectionSettings>(
                configuration.GetSection(nameof(PhoneBookCollectionSettings)));
            services.Configure<PhoneBookEntryCollectionSettings>(
                configuration.GetSection(nameof(PhoneBookEntryCollectionSettings)));

            //Register mongo collections
            services.AddSingleton<IPhoneBookCollectionSettings, PhoneBookCollectionSettings>(sp =>
                sp.GetRequiredService<IOptions<PhoneBookCollectionSettings>>().Value);
            services.AddSingleton<IPhoneBookEntryCollectionSettings, PhoneBookEntryCollectionSettings>(sp =>
                sp.GetRequiredService<IOptions<PhoneBookEntryCollectionSettings>>().Value);

            //Providers
            services.AddSingleton<IPhoneBookService, PhoneBookService>();

            return services;
        }
    }
}
