using System;

namespace Website.Library.Classes
{
    public interface WebsiteOptions
    {
        void AddHeader(string header);

        void AddDescription(string description);

        void AddOption(string name, int value, string description, string reference, int defaultValue, 
            int minValue, int maxValue, bool isGlobal = false);

        void AddOption(string name, double value, string description, string reference, bool isGlobal = false);

        void AddOption(string name, decimal value, string description, string reference, bool isGlobal = false);

        void AddOption(string name, bool value, string description, string reference, bool isGlobal = false);

        void AddOption(string name, string value, string description, string reference, int width = 300,
            bool isPassword = false, bool isCulture = false, int numberOfLines = 1, bool isGlobal = false);

        void AddOption(string name, DateTime value, string description, string reference, bool isGlobal);
    }
}
