
namespace POS.Base.Classes
{
    public enum ApplicationStyle { Classic, Modern }

    /// <summary>
    /// Folder type to be found
    /// </summary>
    public enum FolderType { Root, Images, Dictionary, Backups, Marketing, Languages, Error, Plugins, Temp, Help }

    /// <summary>
    /// Menu location for plugin modules when adding items to the menu system
    /// </summary>
    public enum PluginMenuType { Root, File, Accounts, Tools, Reports, Administration, AdministrationTools, Help }

    /// <summary>
    /// Image Types
    /// </summary>
    public enum ImageTypes
    {
        Logo,

        Products,

        Treatments,

        WebsiteTreatments,

        OfferImages,

        HomePageBanners,

        PageBanners,

        Celebrities
    }

    public enum NodeTypeImage
    {
        Root,

        Folder,

        Image
    }
}
