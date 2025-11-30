namespace ToRead;

/// <summary>
/// Represents an item in the reading list.
/// </summary>
/// <remarks>
/// This class stores information about articles, blog posts, or other content
/// that users want to read later. Each item is automatically assigned a unique
/// identifier and timestamps for tracking creation and updates.
/// </remarks>
public class ReadItem(
    string title,
    string description,
    string url)
{
    /// <summary>
    /// Gets or sets the unique identifier for this reading item.
    /// </summary>
    /// <remarks>
    /// This value is automatically generated when a new item is created.
    /// </remarks>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the title of the reading item.
    /// </summary>
    /// <example>
    /// "10 Best Practices for C# Development"
    /// </example>
    public string Title { get; set; } = title;

    /// <summary>
    /// Gets or sets a brief description or summary of the reading item.
    /// </summary>
    /// <remarks>
    /// This provides additional context about the content without requiring the user to visit the URL.
    /// </remarks>
    /// <example>
    /// "A comprehensive guide covering modern C# development techniques and patterns."
    /// </example>
    public string Description { get; set; } = description;

    /// <summary>
    /// Gets or sets the URL where the content can be accessed.
    /// </summary>
    /// <remarks>
    /// This should be a valid HTTP or HTTPS URL pointing to the content.
    /// </remarks>
    /// <example>
    /// "https://example.com/articles/csharp-best-practices"
    /// </example>
    public string Url { get; set; } = url;

    /// <summary>
    /// Gets or sets the UTC timestamp when this item was created.
    /// </summary>
    /// <remarks>
    /// This value is automatically set when the item is instantiated and represents
    /// the time in Coordinated Universal Time (UTC).
    /// </remarks>
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

    /// <summary>
    /// Gets or sets the UTC timestamp when this item was last updated.
    /// </summary>
    /// <remarks>
    /// This value is automatically set when the item is instantiated. It should be
    /// updated whenever any of the item's properties are modified.
    /// </remarks>
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}