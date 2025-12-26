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
        private static bool _isInitialized = false;
        private static readonly object _initLock = new object();
        
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
            // { "fr-FR", "Francais" },
        };
        
        /// <summary>
        /// Static constructor - initializes with saved or system culture
        /// </summary>
        static LocalizationManager()
        {
            try
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
            catch (Exception ex)
            {
                // Fallback: initialize with Italian if anything goes wrong
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Static constructor error: {ex.Message}");
                SafeInitializeFallback();
            }
        }
        
        /// <summary>
        /// Fallback initialization when normal initialization fails
        /// </summary>
        private static void SafeInitializeFallback()
        {
            try
            {
                _currentCulture = new CultureInfo("it-IT");
                
                _resourceManager = new ResourceManager(
                    "SchoolGrades.Resources.Strings",
                    typeof(SchoolGrades.Resources.Strings).Assembly);
                
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                // Absolute fallback - just set the culture
                _currentCulture = CultureInfo.InvariantCulture;
                _isInitialized = false;
                
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Critical fallback failed: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Initialize or reinitialize the localization system with specified culture
        /// </summary>
        /// <param name="cultureName">Culture name (e.g., "it-IT", "en-US")</param>
        public static void Initialize(string cultureName)
        {
            lock (_initLock)
            {
                if (!SupportedLanguages.ContainsKey(cultureName))
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Unsupported culture '{cultureName}', defaulting to it-IT");
                    cultureName = "it-IT";
                }
                
                _currentCulture = new CultureInfo(cultureName);
                
                try
                {
                    // Create ResourceManager manually to ensure it works in Release builds
                    _resourceManager = new ResourceManager(
                        "SchoolGrades.Resources.Strings",
                        typeof(SchoolGrades.Resources.Strings).Assembly);
                    
                    _isInitialized = true;
                    
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Successfully initialized for culture '{cultureName}'");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Failed to initialize ResourceManager: {ex.Message}");
                    _isInitialized = false;
                }
                
                // Set thread culture for current and future threads
                try
                {
                    Thread.CurrentThread.CurrentUICulture = _currentCulture;
                    Thread.CurrentThread.CurrentCulture = _currentCulture;
                    CultureInfo.DefaultThreadCurrentUICulture = _currentCulture;
                    CultureInfo.DefaultThreadCurrentCulture = _currentCulture;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Failed to set thread culture: {ex.Message}");
                }
            }
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
            if (_resourceManager == null || !_isInitialized)
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: ResourceManager not initialized for key '{key}'");
                return $"[{key}]";
            }
                
            try
            {
                string value = _resourceManager.GetString(key, _currentCulture);
                if (value == null)
                {
                    System.Diagnostics.Debug.WriteLine($"LocalizationManager: Missing resource key '{key}' for culture '{_currentCulture.Name}'");
                    return $"[{key}]";
                }
                return value;
            }
            catch (Exception ex)
            {
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
                return format;
                
            try
            {
                return string.Format(format, args);
            }
            catch (FormatException ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Format error for key '{key}': {ex.Message}");
                return format;
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
            
            if (_currentCulture != null && _currentCulture.Name == cultureName)
                return;
                
            Initialize(cultureName);
            SaveLanguagePreference(cultureName);
            
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }
        
        /// <summary>
        /// Get current application culture
        /// </summary>
        public static CultureInfo CurrentCulture => _currentCulture ?? CultureInfo.InvariantCulture;
        
        /// <summary>
        /// Get current language code (e.g., "it-IT")
        /// </summary>
        public static string CurrentLanguage => _currentCulture?.Name ?? "it-IT";
        
        /// <summary>
        /// Get current language display name (e.g., "Italiano")
        /// </summary>
        public static string CurrentLanguageName => 
            _currentCulture != null && SupportedLanguages.ContainsKey(_currentCulture.Name) 
                ? SupportedLanguages[_currentCulture.Name] 
                : "Italiano";
        
        /// <summary>
        /// Check if a resource key exists
        /// </summary>
        public static bool KeyExists(string key)
        {
            if (_resourceManager == null || !_isInitialized)
                return false;
                
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
                // Non usare Commons.ErrorLog qui per evitare loop
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Error saving language preference: {ex.Message}");
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
                // Non usare Commons.ErrorLog qui per evitare loop durante l'inizializzazione
                System.Diagnostics.Debug.WriteLine($"LocalizationManager: Error loading language preference: {ex.Message}");
                return null;
            }
        }
    }
    
    /// <summary>
    /// Shorthand alias for LocalizationManager.GetString
    /// </summary>
    public static class Loc
    {
        public static string Get(string key) => LocalizationManager.GetString(key);
        public static string Get(string key, params object[] args) => LocalizationManager.GetString(key, args);
    }
}
