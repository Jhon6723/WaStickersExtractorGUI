
# 🧩 WaStickers Extractor GUI

Aplicación de escritorio en C# (.NET 9) con WinForms para extraer y convertir imágenes `.webp` desde archivos `.wastickers` (internamente archivos `.zip` de stickers) al formato `.png`. Ideal para recuperar stickers de WhatsApp exportados.

---

## ✨ Funcionalidades

- Selección de archivo `.wastickers` desde el sistema de archivos.
- Elección de carpeta de destino con creación automática de subcarpeta.
- Extracción de imágenes `.webp` desde el archivo `.wastickers`.
- Conversión automática de `.webp` a `.png` con Magick.NET.
- Eliminación de los archivos `.webp` después de la conversión.
- Visualización de progreso con puntos (`.`) por cada archivo procesado.
- Mensaje "Cargando..." durante el proceso de extracción.
- Apertura automática de la carpeta de destino al finalizar.
- Interfaz moderna con tema oscuro tipo Visual Studio Code.

---

## 🛠️ Tecnologías Usadas

- Lenguaje: C#
- Framework: .NET 9
- Interfaz: Windows Forms (WinForms)
- Librerías:
  - `System.IO.Compression` (para extraer archivos .zip)
  - `System.Windows.Forms` (interfaz gráfica)
  - `System.Drawing` (visualización y estilos)
  - `System.Diagnostics` (para abrir carpeta)
  - `Magick.NET-Q8-AnyCPU` (para conversión de imágenes)

---

## 💻 Requisitos

- Sistema: Windows 64-bit
- .NET 9 instalado (o usar versión *self-contained*)
- Tamaño aprox del `.exe`: 107 MB

---

## 🚀 Ejecutable

Puedes descargar la última versión compilada desde la sección **[Releases](../../releases)** del repositorio.

**Nombre:** `WaStickersExtractorGUI.exe`  
**Ubicación:** Carpeta `release/` o desde la página de Releases

---

## 🧑‍💻 Ejecución manual del proyecto

```bash
dotnet run
```

## 🧪 Compilación como ejecutable

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

Para reducir el peso:
```bash
dotnet publish -c Release -r win-x64 --self-contained false
```

---

## 🎨 Tema Oscuro Aplicado

- Fondo: `Color.FromArgb(30, 30, 30)`
- Botones: `Color.FromArgb(45, 45, 48)` con texto blanco
- Estilo visual plano (`FlatStyle.Flat`) para apariencia moderna

---

## 📦 Commit final sugerido

```txt
feat: extracción, conversión a PNG y apertura de carpeta final

- Se implementa conversión automática de .webp a .png usando Magick.NET.
- Los archivos .webp se eliminan tras la conversión para mantener limpia la carpeta.
- Se muestra una barra de progreso con puntos (.) por cada archivo procesado.
- Se abre automáticamente la carpeta destino con explorer.exe al finalizar.
- Se mantiene un mensaje "Cargando..." mientras el proceso está activo.
```

---

## 🧾 Créditos

Desarrollado con entusiasmo por **Jhon** 😄
