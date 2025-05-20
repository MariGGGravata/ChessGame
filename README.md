# ChessGame
Chess Game for Studies.

#English:
Tip: Generate a Standalone Executable (Single File)
If you want to make things even easier (without needing the .NET Runtime installed), generate a standalone executable:

bash:
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

This creates a single .exe file, with everything built in.

#Portuguese:
Dica: Gerar Executável Autônomo (Single File)
Se quiser facilitar ainda mais (sem precisar do .NET Runtime instalado), gere um executável autônomo:

bash:
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

Isso cria um único arquivo .exe, com tudo embutido.