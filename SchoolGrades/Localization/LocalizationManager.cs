using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace SchoolGrades.Localization
{
    /// <summary>
    /// Centralized manager for application localization.
    /// Manages language resources and provides runtime language switching.
    /// </summary>
    public static class LocalizationManager
    {
        private static ResourceManager _resourceManager;
        private static CultureInfo _currentCulture;
        
        /// <summary>
        /// Event fired when application language changes at runtime
        /// </summary>
        public static event EventHandler LanguageChanged;
        
        /// <summary>
        /// Dictionary of supported languages with their display names
        /// </summary>
        public static readonly Dictionary<string, string> SupportedLanguages = new()
        {
            { "it-IT", "Italiano" },
            { "en-US", "English" }
            // Add more languages here as they become available
            // { "fr-FR", "Français" },
            // { "de-DE", "Deutsch" },
            // { "es-ES", "Español" }
        };
        
        /// <summary>
        /// Static constructor - initializes with saved or system culture
        /// </summary>
        static LocalizationManager()
        {
            // Try to load saved language preference
            string savedLanguage = LoadLanguagePreference();
            
            // If no saved preference, use system culture or default to Italian
            if (string.IsNullOrEmpty(savedLanguage))
            {
                savedLanguage = CultureInfo.CurrentUICulture.Name;
                if (!SupportedLanguages.ContainsKey(savedLanguage))
                {
                    // Check if we support the language without region (e.g., "en" for "en-GB")
                    string languageOnly = savedLanguage.Split('-')[0];
                    bool found = false;
                    foreach (string key in SupportedLanguages.Keys)
                    {
                        if (key.StartsWith(languageOnly))
                        {
                            savedLanguage = key;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        savedLanguage = "it-IT"; // Default to Italian
                }
            }
                
            Initialize(savedLanguage);
        }
        
        /// <summary>
        /// Initialize or reinitialize the localization system with specified culture
        /// </summary>
        /// <param name="cultureName">Culture name (e.g., "it-IT", "en-US")</param>
        public static void Initialize(string cultureName)
        {
            if (!SupportedLanguages.ContainsKey(cultureName))
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Unsupported culture '{cultureName}', defaulting to it-IT");
                cultureName = "it-IT";
            }
            
            _currentCulture = new CultureInfo(cultureName);
            
            try
            {
                // Try the standard way first
                _resourceManager = new ResourceManager(
                    "SchoolGrades.Resources.Strings", 
                    typeof(LocalizationManager).Assembly);
                
                // Test if resource manager can actually load resources
                string test = _resourceManager.GetString("Common_Save", _currentCulture);
                if (test == null)
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Resource 'Common_Save' not found for culture '{cultureName}'. Trying alternative approach...");
                    
                    // Alternative: Use the generated Strings class directly
                    try
                    {
                        var stringsType = typeof(LocalizationManager).Assembly.GetType("SchoolGrades.Resources.Strings");
                        if (stringsType != null)
                        {
                            var resourceManagerProperty = stringsType.GetProperty("ResourceManager", 
                                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                            if (resourceManagerProperty != null)
                            {
                                _resourceManager = (ResourceManager)resourceManagerProperty.GetValue(null);
                                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Using alternative ResourceManager from Strings class");
                            }
                        }
                    }
                    catch (Exception altEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"LocalizationManager: Alternative approach failed: {altEx.Message}");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Successfully loaded resources for culture '{cultureName}'. Test string: '{test}'");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Failed to initialize ResourceManager: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Stack trace: {ex.StackTrace}");
                
                // Try using the generated Strings class as fallback
                try
                {
                    _resourceManager = SchoolGrades.Resources.Strings.ResourceManager;
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Fallback to Strings.ResourceManager successful");
                }
                catch (Exception fallbackEx)
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Fallback also failed: {fallbackEx.Message}");
                }
            }
            
            // Set thread culture for current and future threads
            Thread.CurrentThread.CurrentUICulture = _currentCulture;
            Thread.CurrentThread.CurrentCulture = _currentCulture;
            
            // Also set default culture for new threads
            CultureInfo.DefaultThreadCurrentUICulture = _currentCulture;
            CultureInfo.DefaultThreadCurrentCulture = _currentCulture;
        }
        
        /// <summary>
        /// Get localized string by resource key
        /// </summary>
        /// <param name="key">Resource key (e.g., "Common_Save")</param>
        /// <returns>Localized string or [key] if not found</returns>
        public static string GetString(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            
            // Check if resource manager was initialized successfully
            if (_resourceManager == null)
            {
                // Log silenzioso - non chiamare ErrorLog che fa beep
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: ResourceManager is null, cannot get string for key '{key}'");
                return $"[{key}]";
            }
                
            try
            {
                string value = _resourceManager.GetString(key, _currentCulture);
                if (value == null)
                {
                    // Log silenzioso - non chiamare ErrorLog per chiavi mancanti (troppo rumore)
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Missing resource key '{key}' for culture '{_currentCulture.Name}'");
                    return $"[{key}]"; // Return key in brackets to make missing translations visible
                }
                return value;
            }
            catch (Exception ex)
            {
                // Log silenzioso - non chiamare ErrorLog che fa beep
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Error getting string for key '{key}': {ex.Message}");
                return $"[{key}]";
            }
        }
        
        /// <summary>
        /// Get formatted localized string with parameters
        /// </summary>
        /// <param name="key">Resource key</param>
        /// <param name="args">Format arguments</param>
        /// <returns>Formatted localized string</returns>
        public static string GetString(string key, params object[] args)
        {
            string format = GetString(key);
            if (format.StartsWith("[") && format.EndsWith("]"))
                return format; // Key not found, return as-is
                
            try
            {
                return string.Format(format, args);
            }
            catch (FormatException ex)
            {
                // Log silenzioso
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Format error for key '{key}': {ex.Message}");
                return format; // Return unformatted string
            }
        }
        
        /// <summary>
        /// Change application language at runtime
        /// </summary>
        /// <param name="cultureName">New culture name (e.g., "en-US")</param>
        public static void ChangeLanguage(string cultureName)
        {
            if (!SupportedLanguages.ContainsKey(cultureName))
                throw new ArgumentException($"Unsupported culture: {cultureName}");
            
            if (_currentCulture.Name == cultureName)
                return; // Already using this language
                
            Initialize(cultureName);
            SaveLanguagePreference(cultureName);
            
            // Notify subscribers that language changed
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }
        
        /// <summary>
        /// Get current application culture
        /// </summary>
        public static CultureInfo CurrentCulture => _currentCulture;
        
        /// <summary>
        /// Get current language code (e.g., "it-IT")
        /// </summary>
        public static string CurrentLanguage => _currentCulture.Name;
        
        /// <summary>
        /// Get current language display name (e.g., "Italiano")
        /// </summary>
        public static string CurrentLanguageName => SupportedLanguages[_currentCulture.Name];
        
        /// <summary>
        /// Check if a resource key exists
        /// </summary>
        public static bool KeyExists(string key)
        {
            try
            {
                return _resourceManager.GetString(key, _currentCulture) != null;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Save language preference to application settings
        /// </summary>
        private static void SaveLanguagePreference(string cultureName)
        {
            try
            {
                Properties.Settings.Default.Language = cultureName;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"LocalizationManager: Error saving language preference: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Load language preference from application settings
        /// </summary>
        private static string LoadLanguagePreference()
        {
            try
            {
                return Properties.Settings.Default.Language;
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"LocalizationManager: Error loading language preference: {ex.Message}");
                return null;
            }
        }
    }
    
    /// <summary>
    /// Shorthand alias for LocalizationManager.GetString
    /// Usage: Loc.GetString("Common_Save") or just Loc.Get("Common_Save")
    /// </summary>
    public static class Loc
    {
        public static string Get(string key) => LocalizationManager.GetString(key);
        public static string Get(string key, params object[] args) => LocalizationManager.GetString(key, args);
    }
}
