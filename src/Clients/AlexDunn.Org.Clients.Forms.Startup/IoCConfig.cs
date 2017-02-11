using AlexDunn.Org.Definitions.Business.Services;
using AlexDunn.Org.Definitions.Data.Providers;
using AlexDunn.Org.Definitions.Data.Repositories;
using AlexDunn.Org.Infrastructure.Business.Services;
using AlexDunn.Org.Infrastructure.Data.Providers;
using AlexDunn.Org.Infrastructure.Data.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Clients.Forms.Startup
{
    public class IoCConfig
    {
        public IoCConfig()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public void RegisterServices()
        {
            SimpleIoc.Default.Register<IPostService, PostService>();
        }

        public void RegisterProviders()
        {
            SimpleIoc.Default.Register<IPostDataProvider, PostDataProvider>();
        }

        public void RegisterRepositories()
        {
            SimpleIoc.Default.Register<IPostRepository, PostRepository>();
            SimpleIoc.Default.Register<ISiteRepository, SiteRepository>();
        }

        public void RegisterViewModel<T>() where T : ViewModelBase
        {
            SimpleIoc.Default.Register<T>();
        }
        public T FindViewModel<T>() where T : ViewModelBase
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
        public void RegisterNavigationService(INavigationService navigationService)
        {
            SimpleIoc.Default.Unregister<INavigationService>();
            SimpleIoc.Default.Register(() => navigationService);
        }
    }
}
