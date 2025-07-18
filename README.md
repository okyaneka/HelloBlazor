# Hello Blazor

Using Dotnet 8

Run

```bash
dotnet watch run
```

Build & Run

```bash
dotnet publish -c Release -o ./publish
cd publish
dotnet HelloBlazor.dll
```

Docker

```bash
docker build -t hello-blazor .
docer run -p 8080:8080 hello-blazor
```
