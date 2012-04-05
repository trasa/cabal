using System.ComponentModel;
using System.Windows;
using Cabal.Client.Core.Services;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Core.Infrastructure
{
    public static class RegionPopupBehaviors
    {

        /// <summary>
        /// The name of the Popup <see cref="IRegion"/>.
        /// </summary>
        public static readonly DependencyProperty CreatePopupRegionWithNameProperty =
            DependencyProperty.RegisterAttached("CreatePopupRegionWithName", typeof(string), typeof(RegionPopupBehaviors), new PropertyMetadata(CreatePopupRegionWithNamePropertyChanged));

        /// <summary>
        /// The <see cref="Style"/> to set to the Popup.
        /// </summary>
        public static readonly DependencyProperty ContainerWindowStyleProperty =
          DependencyProperty.RegisterAttached("ContainerWindowStyle", typeof(Style), typeof(RegionPopupBehaviors), null);

        /// <summary>
        /// Gets the name of the Popup <see cref="IRegion"/>.
        /// </summary>
        /// <param name="owner">Owner of the Popup.</param>
        /// <returns>The name of the Popup <see cref="IRegion"/>.</returns>
        public static string GetCreatePopupRegionWithName(DependencyObject owner)
        {
            return owner.GetValue(CreatePopupRegionWithNameProperty) as string;
        }

        /// <summary>
        /// Sets the name of the Popup <see cref="IRegion"/>.
        /// </summary>
        /// <param name="owner">Owner of the Popup.</param>
        /// <param name="value">Name of the Popup <see cref="IRegion"/>.</param>
        public static void SetCreatePopupRegionWithName(DependencyObject owner, string value)
        {
            owner.SetValue(CreatePopupRegionWithNameProperty, value);
        }

        /// <summary>
        /// Gets the <see cref="Style"/> for the Popup.
        /// </summary>
        /// <param name="owner">Owner of the Popup.</param>
        /// <returns>The <see cref="Style"/> for the Popup.</returns>
        public static Style GetContainerWindowStyle(DependencyObject owner)
        {
            return owner.GetValue(ContainerWindowStyleProperty) as Style;
        }

        /// <summary>
        /// Sets the <see cref="Style"/> for the Popup.
        /// </summary>
        /// <param name="owner">Owner of the Popup.</param>
        /// <param name="style"><see cref="Style"/> for the Popup.</param>
        public static void SetContainerWindowStyle(DependencyObject owner, Style style)
        {
            owner.SetValue(ContainerWindowStyleProperty, style);
        }

        /// <summary>
        /// Creates a new <see cref="IRegion"/> and registers it in the default <see cref="IRegionManager"/>
        /// attaching to it a <see cref="DialogActivationBehavior"/> behavior.
        /// </summary>
        /// <param name="owner">The owner of the Popup.</param>
        /// <param name="regionName">The name of the <see cref="IRegion"/>.</param>
        /// <remarks>
        /// This method would typically not be called directly, instead the behavior 
        /// should be set through the Attached Property <see cref="CreatePopupRegionWithNameProperty"/>.
        /// </remarks>
        public static void RegisterNewPopupRegion(DependencyObject owner, string regionName)
        {
            // Creates a new region and registers it in the default region manager.
            // Another option if you need the complete infrastructure with the default region behaviors
            // is to extend DelayedRegionCreationBehavior overriding the CreateRegion method and create an 
            // instance of it that will be in charge of registering the Region once a RegionManager is
            // set as an attached property in the Visual Tree.
            var regionManager = ClientIoCContainer.Container.GetInstance<IRegionManager>();
            if (regionManager != null)
            {
                IRegion region = new SingleActiveRegion();
                DialogActivationBehavior behavior = new WindowDialogActivationBehavior {HostControl = owner};

                region.Behaviors.Add(DialogActivationBehavior.BehaviorKey, behavior);
                if (!regionManager.Regions.ContainsRegionWithName(regionName))
                {
                    regionManager.Regions.Add(regionName, region);
                }
            }
        }

        private static void CreatePopupRegionWithNamePropertyChanged(DependencyObject hostControl, DependencyPropertyChangedEventArgs e)
        {
            if (IsInDesignMode(hostControl))
            {
                return;
            }

            RegisterNewPopupRegion(hostControl, e.NewValue as string);
        }

        private static bool IsInDesignMode(DependencyObject element)
        {
            // Due to a known issue in Cider, GetIsInDesignMode attached property value is not enough to know if it's in design mode.
            return DesignerProperties.GetIsInDesignMode(element) || Application.Current == null
                   || Application.Current.GetType() == typeof(Application);
        }
    }
}
