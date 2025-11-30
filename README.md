# Scalar for Documenting .Net Web APIs

Since .NET 9 no longer includes Swagger UI in the default Web API templates, we need to manually set up Swagger UI or another tool if we want visual API documentation in a new project. Scalar is a good option for this purpose and can be used as a replacement for Swagger UI.

## Installing and Configuring Scalar

```bash
dotnet add package Scalar.AspNetCore
```

```csharp
// ...
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // adding scalar docs
    app.MapScalarApiReference();
}

// ...
```

This is all we need to enable Scalar. Of course, there are many additional configuration options available, such as versioning, contact information, API titles, and more (similar to what we can configure with Swagger).

## Scalar Look and Feel

Scalar provides a modern and intuitive UI and great DX:


<img width="1635" height="960" alt="image" src="https://github.com/user-attachments/assets/f37232eb-0b8d-4465-a423-127bf67e3606" />
