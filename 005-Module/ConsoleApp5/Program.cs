using System;
using System.IO;
using System.Reflection;

// Custom Attribute
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ConfigurationItemAttribute : Attribute
{
    public string SettingName { get; }
    public Type ProviderType { get; }

    public ConfigurationItemAttribute(string settingName, Type providerType)
    {
        SettingName = settingName;
        ProviderType = providerType;
    }
}

// Configuration Providers
public interface IConfigurationProvider
{
    void Save(string key, string value);
    string Load(string key);
}

public class FileConfigurationProvider : IConfigurationProvider
{
    private readonly string _filePath;

    // Parameterless constructor
    public FileConfigurationProvider() : this("config.txt") { }

    public FileConfigurationProvider(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(string key, string value)
    {
        File.WriteAllText(_filePath, $"{key}={value}");
    }

    public string Load(string key)
    {
        if (File.Exists(_filePath))
        {
            var content = File.ReadAllText(_filePath);
            var parts = content.Split('=');
            if (parts[0] == key)
            {
                return parts[1];
            }
        }
        return null;
    }
}

public class InMemoryConfigurationProvider : IConfigurationProvider
{
    private readonly System.Collections.Generic.Dictionary<string, string> _settings = 
        new System.Collections.Generic.Dictionary<string, string>();

    public void Save(string key, string value)
    {
        _settings[key] = value;
    }

    public string Load(string key)
    {
        _settings.TryGetValue(key, out var value);
        return value;
    }
}

// Base Class for Handling Configuration
public class ConfigurationComponentBase
{
    public void LoadSettings()
    {
        var properties = GetType().GetProperties();
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();
            if (attribute != null)
            {
                var provider = (IConfigurationProvider)Activator.CreateInstance(attribute.ProviderType);
                var value = provider.Load(attribute.SettingName);
                if (value != null)
                {
                    property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
                }
            }
        }
    }

    public void SaveSettings()
    {
        var properties = GetType().GetProperties();
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();
            if (attribute != null)
            {
                var provider = (IConfigurationProvider)Activator.CreateInstance(attribute.ProviderType);
                var value = property.GetValue(this);
                provider.Save(attribute.SettingName, value.ToString());
            }
        }
    }
}

// MyAppSettings Class
public class MyAppSettings : ConfigurationComponentBase
{
    [ConfigurationItem("FileSetting", typeof(FileConfigurationProvider))]
    public string FileSetting { get; set; }

    [ConfigurationItem("MemorySetting", typeof(InMemoryConfigurationProvider))]
    public int MemorySetting { get; set; }
}

// Main Program
class Program
{
    static void Main()
    {
        var settings = new MyAppSettings
        {
            FileSetting = "InitialFileValue",
            MemorySetting = 42
        };

        // Save settings
        settings.SaveSettings();

        // Load settings
        settings.LoadSettings();

        Console.WriteLine($"FileSetting: {settings.FileSetting}");
        Console.WriteLine($"MemorySetting: {settings.MemorySetting}");
    }
}